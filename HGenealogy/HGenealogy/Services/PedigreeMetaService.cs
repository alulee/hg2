using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;

namespace HGenealogy.Services
{
    public class PedigreeMetaService : IPedigreeMetaService
    {
        private readonly IRepository<PedigreeMeta> _pedigreeMetaRepository;

        public PedigreeMetaService(
            IRepository<PedigreeMeta> pedigreeMetaRepository)
        {
            this._pedigreeMetaRepository = pedigreeMetaRepository;
        }

        public IQueryable<PedigreeMeta> GetAll()
        {
            return _pedigreeMetaRepository.GetAll();
        }

        public PedigreeMeta GetById(int id)
        {
            return _pedigreeMetaRepository.GetAll().Where(p => p.Id == id)
                                          .FirstOrDefault();
        }

        public void Insert(PedigreeMeta entity)
        {
            _pedigreeMetaRepository.Create(entity);
            _pedigreeMetaRepository.SaveChanges();
        }
        public void Update(PedigreeMeta entity)
        {
            _pedigreeMetaRepository.Update(entity);
            _pedigreeMetaRepository.SaveChanges();
        }
    }
}