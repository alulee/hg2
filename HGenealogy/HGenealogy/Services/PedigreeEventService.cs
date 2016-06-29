using System;
using System.Collections.Generic;
using System.Linq;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;

namespace HGenealogy.Services
{
    public class PedigreeEventService : IPedigreeEventService
    {
        private readonly IRepository<PedigreeEvent> _pedigreeEventRepository;

        public PedigreeEventService(
            IRepository<PedigreeEvent> pedigreeEventRepository)
        {
            this._pedigreeEventRepository = pedigreeEventRepository;
        }

        public IQueryable<PedigreeEvent> GetAll()
        {

            return _pedigreeEventRepository.GetAll();
        }

        public PedigreeEvent GetById(int id)
        {
            return _pedigreeEventRepository.GetAll().Where(p => p.Id==id)
                                          .FirstOrDefault();
            
        }

        public void Insert(PedigreeEvent entity)
        {
            _pedigreeEventRepository.Create(entity);
            _pedigreeEventRepository.SaveChanges();
        }

        public void Update(PedigreeEvent entity)
        {
            _pedigreeEventRepository.Update(entity);
            _pedigreeEventRepository.SaveChanges();
        }

        public void Delete(PedigreeEvent entity)
        {
            _pedigreeEventRepository.Delete(entity);
            _pedigreeEventRepository.SaveChanges();
        }
    }
}