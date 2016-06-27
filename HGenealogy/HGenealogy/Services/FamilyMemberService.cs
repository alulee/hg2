using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using System.Linq.Expressions;
using System.Web.Mvc;
using LinqKit;

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
            filter = filter.And(p => p.PedigreeId.Equals(pedigreeId));
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


    }
}