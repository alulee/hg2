using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using HGenealogy.Models.PedigreeMeta;
using LinqKit;
using System.Web.Mvc;

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
        public List<PedigreeMeta> GetPedigreeMetaList(PedigreeMetaQueryModel queryModel)
        {
            var filter = PredicateBuilder.True<PedigreeMeta>();
            if (!string.IsNullOrEmpty(queryModel.Title))
                filter = filter.And(p=>p.Title.Contains(queryModel.Title));

            //var query = _pedigreeMetaRepository.GetAll().Where(filter.Compile());
            var query = _pedigreeMetaRepository.GetRows(filter);
            
            var result = query.ToList();
            return result;
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

        public List<SelectListItem> GetAvailablePedigreeSelectList(int currentPedigreeId = 0)
        {
            List<SelectListItem> availablePedigreeList = new List<SelectListItem>();
            if (currentPedigreeId == 0)
            {
                availablePedigreeList.Add(new SelectListItem { Text = "請選擇族譜", Value = "", Selected = true });
            }
            else
            {
                availablePedigreeList.Add(new SelectListItem { Text = "請選擇族譜", Value = ""});
            }

            var result = this.GetAll().ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    availablePedigreeList.Add(new SelectListItem
                    {
                        Text = item.Id.ToString(),
                        Value = item.Title,
                        Selected = (currentPedigreeId == item.Id)
                    });
                }
            }
            return availablePedigreeList;
        }
    }
}