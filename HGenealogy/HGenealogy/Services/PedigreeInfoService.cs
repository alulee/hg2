using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using System.Linq.Expressions;

namespace HGenealogy.Services
{
    public class PedigreeInfoService : IPedigreeInfoService
    {
        private readonly IRepository<PedigreeInfo> _pedigreeInfoRepository;

        public PedigreeInfoService(
            IRepository<PedigreeInfo> pedigreeInfoRepository)
        {
            this._pedigreeInfoRepository = pedigreeInfoRepository;
        }

        public IQueryable<PedigreeInfo> GetAll()
        {
            
            return _pedigreeInfoRepository.GetAll();
        }

        public PedigreeInfo GetById(int id)
        {
            return _pedigreeInfoRepository.GetAll().Where(p => p.Id == id)
                                          .FirstOrDefault();
        }

        public void Insert(PedigreeInfo entity)
        {
            _pedigreeInfoRepository.Create(entity);
            _pedigreeInfoRepository.SaveChanges();
        }

        public void Update(PedigreeInfo entity)
        {
            _pedigreeInfoRepository.Update(entity);
            _pedigreeInfoRepository.SaveChanges();
        }

        public void Delete(PedigreeInfo entity)
        {
            _pedigreeInfoRepository.Delete(entity);
            _pedigreeInfoRepository.SaveChanges();
        }
    }
}