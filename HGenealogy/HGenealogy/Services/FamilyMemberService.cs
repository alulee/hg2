using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using System.Linq.Expressions;

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

    }
}