using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Services.Interface;
using HGenealogy.Data;

namespace HGenealogy.Services.Genealogy
{
    public class FamilyService : IFamilyService
    {

        public IList<Family> GetFamiliesByGeneID(string geneID)
        {
            List<Family> result = new List<Family>();

            using (var db = new hDatabaseEntities())
            {
                if (!(string.IsNullOrEmpty(geneID) || geneID == ""))
                {
                    result = (from families in db.Families
                              where families.GId == geneID
                              select families)
                              .OrderBy(x => x.GenerationNo.ToString() + x.GFatherName ?? "" + x.FatherName ?? "" + x.FName ?? "")
                              .ToList<Family>();

                }
            }
            return result;
        }

        public Family GetFamilyByName(string geneMetaID, string fName, string fatherName)
        {            
            using (var db = new hDatabaseEntities())
            {
                if (!(string.IsNullOrEmpty(fName) || fName == ""))
                {
                    var result = (from families in db.Families
                                  where families.GId == geneMetaID &&
                                        families.FName == fName 
                                  select families);

                    if (result != null && result.Count() == 1)
                    {
                        return result.FirstOrDefault();
                    }
                    else if(result != null && result.Count()> 1)
                    {
                        result = (from families in db.Families
                                  where families.GId == geneMetaID &&
                                        families.FName == fName &&
                                        families.FatherName ==fatherName
                                  select families);
                        if (result != null && result.Count() == 1)
                        {
                            return result.FirstOrDefault();
                        }
                    }
                }                
            }

            return null;
        }

        public IList<Family> GetFamilyTreeByID(string geneID, int fId)
        {
            IList<Family> myReturn = new List<Family>();
 
            //if (string.IsNullOrEmpty(geneMetaID) || geneMetaID == "") return myReturn;
            if (fId == null) return myReturn;
           
            using (var db = new hDatabaseEntities())
            {
                if (fId == 0)
                {
                    return db.Families.Where(x => x.GId == geneID).ToList<Family>();
                }

                Family startMember = db.Families.Find(fId);
                if (startMember != null)
                {
                    myReturn.Add(startMember);
                    IList<Family> myAncestor = GetAncestorFamily(startMember, 9999);
                    if (myAncestor != null && myAncestor.Count > 0)
                        myReturn = myReturn.Union(myAncestor).ToList<Family>();

                    IList<Family> myDescendant = GetDescendantFamily(startMember, 9999);
                    if (myDescendant != null && myDescendant.Count > 0)
                        myReturn = myReturn.Union(myDescendant).ToList<Family>(); 
                }
            }

            return myReturn;
        }

        // 向上求先祖輩世系
        public IList<Family> GetAncestorFamily(Family startMember, int generationCount)
        {
            IList<Family> myReturn = new List<Family>();
            string fatherID = "";
            int nextFamilyID = 0;
            int generationGot = 0;
            Family nextFamily = startMember;

            using (var db = new hDatabaseEntities())
            {
                
                while (generationGot <= generationCount)
                {
                    fatherID = nextFamily.FatherId;
                    if (!int.TryParse(fatherID, out nextFamilyID))
                        break;

                    nextFamily = db.Families.Find(nextFamilyID);
                    if (nextFamily != null && nextFamily.GId == startMember.GId)
                        myReturn.Add(nextFamily);
                    else
                        break;

                    generationGot++;
                }
            }

            return myReturn;
        }

        // 向下求子孫世系
        public IList<Family> GetDescendantFamily(Family startMember, int generationCount)
        {
            IList<Family> myReturn = new List<Family>();
            int myCurrentID = 0;
            string myFatherName = "";
            int nextFamilyID = 0;
            int generationGot = 0;
            Family nextFamily = startMember;

            using (var db = new hDatabaseEntities())
            {
                while (generationGot <= generationCount)
                {
                    myCurrentID = nextFamily.Id;
                    myFatherName = nextFamily.FatherName;
                    nextFamily = null;
 
                    var result = db.Families
                                    .Where(x => x.GId == startMember.GId &&
                                                x.FatherId == myCurrentID.ToString());
                    if (result != null && result.Count() == 1)
                    {
                        nextFamily = result.FirstOrDefault();
                    }
                    else if (result != null && result.Count() > 1)                    
                    {
                        try
                        {
                            result = db.Families
                                        .Where(x => x.GId == startMember.GId &&
                                                    x.FatherId == myCurrentID.ToString() &&
                                                    x.GFatherName == myFatherName);
                            if (result != null && result.Count() == 1)
                            {
                                nextFamily = result.FirstOrDefault();
                            }
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                        }
                    }


                    if (nextFamily != null && nextFamily.GId == startMember.GId)
                        myReturn.Add(nextFamily);
                    else
                        break;

                    generationGot++;
                }
            }

            return myReturn;
        }

        public IList<Family> GetFamiliesWithNoFatherIDByGeneID(string geneID)
        {
            List<Family> result = new List<Family>();

            using (var db = new hDatabaseEntities())
            {
                if (!(string.IsNullOrEmpty(geneID) || geneID == ""))
                {
                    result = (from families in db.Families
                              where families.GId == geneID && 
                              ( string.IsNullOrEmpty(families.FatherId) || families.FatherId =="")
                              select families)
                              .OrderBy(x => x.GenerationNo.ToString() + x.GFatherName ?? "" + x.FatherName ?? "" + x.FName ?? "")
                              .ToList<Family>();

                }
            }
            return result;
        }

        public IList<Family> GetFamiliesWithNoLatLng(string geneID)
        {
            List<Family> result = new List<Family>();
            using (var db = new hDatabaseEntities())
            {
                if (!(string.IsNullOrEmpty(geneID) || geneID == ""))
                {
                    result = (from families in db.Families
                              where families.GId == geneID &&
                              (families.AddressLatitude == null || families.AddressLongitude == null)
                              select families)
                              .OrderBy(x => x.GenerationNo.ToString() + x.GFatherName ?? "" + x.FatherName ?? "" + x.FName ?? "")
                              .ToList<Family>();

                }
            }
            return result;
        }
    }
}