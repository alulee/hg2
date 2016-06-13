using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using System.Linq.Expressions;

namespace HGenealogy.Services
{
    public class FamilyMemberInfoService : IFamilyMemberInfoService
    {
        private readonly IRepository<FamilyMemberInfo> _familyMemberInfoRepository;

        public FamilyMemberInfoService(
            IRepository<FamilyMemberInfo> familyMemberInfoRepository)
        {
            this._familyMemberInfoRepository = familyMemberInfoRepository;
        }

        public IQueryable<FamilyMemberInfo> GetAll()
        {

            return _familyMemberInfoRepository.GetAll();
        }

        public FamilyMemberInfo GetById(int id)
        {
            return _familyMemberInfoRepository.GetAll().Where(p => p.Id == id)
                                          .FirstOrDefault();
        }

        public void Insert(FamilyMemberInfo entity)
        {
            _familyMemberInfoRepository.Create(entity);
            _familyMemberInfoRepository.SaveChanges();
        }

        public void Update(FamilyMemberInfo entity)
        {
            _familyMemberInfoRepository.Update(entity);
            _familyMemberInfoRepository.SaveChanges();
        }

        public void Delete(FamilyMemberInfo entity)
        {
            _familyMemberInfoRepository.Delete(entity);
            _familyMemberInfoRepository.SaveChanges();
        }
    }
}