using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Models.PedigreeMeta;
using System.Web.Mvc;

namespace HGenealogy.Services.Interface
{
    public interface IPedigreeMetaService
    {
        IQueryable<PedigreeMeta> GetAll();
        List<PedigreeMeta> GetPedigreeMetaList(PedigreeMetaQueryModel queryModel);
        PedigreeMeta GetById(int id);
        void Insert(PedigreeMeta entity);
        void Update(PedigreeMeta entity);
        List<SelectListItem> GetAvailablePedigreeSelectList(int currentPedigreeId = 0);
    }
}