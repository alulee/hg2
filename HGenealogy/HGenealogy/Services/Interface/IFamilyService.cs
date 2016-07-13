using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;
using HGenealogy.Models.FamilyMember;

namespace HGenealogy.Services.Interface
{
    public interface IFamilyService
    {
        IList<Family> GetFamiliesByGeneID(string geneID);
        Family GetFamilyByName(string geneMetaID, string fName, string fatherName);
        IList<Family> GetFamiliesWithNoFatherIDByGeneID(string geneID);
        IList<Family> GetFamiliesWithNoLatLng(string geneID);
        IList<Family> GetFamilyTreeByID(string geneID, int fId);
       
    }
}