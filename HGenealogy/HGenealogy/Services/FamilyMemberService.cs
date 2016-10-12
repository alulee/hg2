using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using System.Linq.Expressions;
using System.Web.Mvc;
using LinqKit;
using HGenealogy.Models.FamilyMember;

namespace HGenealogy.Services
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IRepository<FamilyMember> _familyMemberRepository;

        public FamilyMemberService(
            IRepository<FamilyMember> familyMemberRepository)
        {
            this._familyMemberRepository = familyMemberRepository;
        }

        public IQueryable<FamilyMember> GetAll()
        {
            return _familyMemberRepository.GetAll();
        }

        public FamilyMember GetById(int id)
        {
            return _familyMemberRepository.GetAll().Where(p => p.Id == id)
                                          .FirstOrDefault();
        }

        public void Insert(FamilyMember entity)
        {
            _familyMemberRepository.Create(entity);
            _familyMemberRepository.SaveChanges();
        }
        public void Update(FamilyMember entity)
        {
            _familyMemberRepository.Update(entity);
            _familyMemberRepository.SaveChanges();
        }

        public void Delete(FamilyMember entity)
        {
            _familyMemberRepository.Delete(entity);
            _familyMemberRepository.SaveChanges();
        }

        public void CommitChanges()
        {
            _familyMemberRepository.SaveChanges();
        }

        public List<FamilyMember> GetList(Expression<Func<FamilyMember, bool>> filter)
        {
            var query = this._familyMemberRepository.GetRows(filter);
            var result = query.ToList();
            return result;
        }
      
        public List<SelectListItem> GetFamilyMembersSelectList(int pedigreeId)
        {
            List<SelectListItem> mySelectListItem = new List<SelectListItem>();
            var filter = PredicateBuilder.True<FamilyMember>();
            filter = filter.And(p => p.PedigreeId.Equals(pedigreeId) && pedigreeId > 0);
            var queryresult = this.GetList(filter);
            int index = 0;

            mySelectListItem.Add(new SelectListItem()
            {
                Text = "",
                Value = "0",
                Selected = true
            });

            if (queryresult != null && queryresult.Count() > 0)
            {
                foreach (var f in queryresult)
                {
                    mySelectListItem.Add(new SelectListItem()
                    {
                        Text = string.Format("{0}世 - {1}", f.GenerationSeq, f.GivenName),
                        Value = f.Id.ToString(),
                        Selected = f.Id == queryresult.First().Id
                    });
                    if (index == 0)
                    {
                        mySelectListItem.First().Selected = false;
                    }
                    index++;
                }
            }
            return mySelectListItem;
        }

        public List<FamilyMember> GetFamilyMemberListByPedigreeId(string pedigreeId)
        {
            if (pedigreeId == "")
                return null;

            var filter = PredicateBuilder.True<FamilyMember>();
            filter = filter.And(p => p.PedigreeId.ToString().Equals(pedigreeId));
            var queryresult = this.GetList(filter);

            return queryresult;
        }

        public List<FamilyMember> GetFamilyMemberListByFatherMemberId(string fatherMemberId)
        {
            if (fatherMemberId == "" || fatherMemberId == "0")
                return null;

            var filter = PredicateBuilder.True<FamilyMember>();
            filter = filter.And(p => p.FatherMemberId.ToString().Equals(fatherMemberId));
            var queryresult = this.GetList(filter);

            return queryresult;
        }

        public List<FamilyMember> GetFamilyMemberList(FamilyMemberSimpleQueryModel queryModel)
        {
            var filter = PredicateBuilder.True<FamilyMember>();

            if (!string.IsNullOrEmpty(queryModel.PedigreeId))
                filter = filter.And(p => p.PedigreeId.ToString().Equals(queryModel.PedigreeId));

            if (!string.IsNullOrEmpty(queryModel.GivenName))
                filter = filter.And(p => p.GivenName.Contains(queryModel.GivenName));

            if (!string.IsNullOrEmpty(queryModel.GenearationSeq))
                filter = filter.And(p => p.GenerationSeq.ToString().Equals(queryModel.GenearationSeq));

            var query = _familyMemberRepository.GetRows(filter);

            var result = query.ToList();
            return result;
        }

        public List<FamilyMember> GetLinealFamilyTreeByID(string pedigreeId, string familyMemberId)
        {
            int ifamilyMemberId = 0;

            List<FamilyMember> myReturn = new List<FamilyMember>();

            if (string.IsNullOrEmpty(pedigreeId) || pedigreeId == "") return myReturn;
            if (string.IsNullOrEmpty(familyMemberId) || familyMemberId == "") return myReturn;

            if (familyMemberId == "0")
            {
                return this.GetFamilyMemberListByPedigreeId(pedigreeId).ToList();
            }

            Int32.TryParse(familyMemberId, out ifamilyMemberId);

            FamilyMember startMember = this.GetById(ifamilyMemberId);
                if (startMember != null)
                {
                    myReturn.Add(startMember);

                    // 父輩
                    List<FamilyMember> myAncestor = GetAncestorFamily(startMember, 9999);
                    if (myAncestor != null && myAncestor.Count > 0)
                        myReturn = myReturn.Union(myAncestor).ToList<FamilyMember>();

                    // 子孫輩
                    List<FamilyMember> myDescendant = new List<FamilyMember>();
                    GetDescendantFamily(myDescendant, startMember, 9999, false);
                    if (myDescendant != null && myDescendant.Count > 0)
                        myReturn = myReturn.Union(myDescendant).ToList<FamilyMember>();
                }
            
            return myReturn;
        }

        // 向上求先祖輩世系
        public List<FamilyMember> GetAncestorFamily(FamilyMember startMember, int generationCount)
        {
            List<FamilyMember> myReturn = new List<FamilyMember>();
            int fatherID = 0;
            int generationGot = 0;
            FamilyMember nextFamily = startMember;
 
            while (generationGot <= generationCount)
            {
                fatherID = nextFamily.FatherMemberId;
                if (fatherID == 0)
                    break;

                nextFamily = this.GetById(fatherID);
                if (nextFamily != null)
                    myReturn.Add(nextFamily);
                else
                    break;

                generationGot++;
            }
            
            return myReturn;
        }

        // 向下求子孫世系
        public void GetDescendantFamily(List<FamilyMember> result, FamilyMember startMember, int generationCount, bool isIncluedStartMember = false)
        {
            if (startMember == null)
                return;

            if (generationCount <= 0)
                return;

            if (isIncluedStartMember)
            {
                result.Add(startMember);
            }

            // 所有的子輩
            var children = this.GetFamilyMemberListByFatherMemberId(startMember.Id.ToString());
            if (children != null && children.Count() > 0)
            {
                foreach (var child in children)
                {
                    this.GetDescendantFamily(result, child, generationCount - 1, true);
                }
            } 
        }
    
    
    }
}