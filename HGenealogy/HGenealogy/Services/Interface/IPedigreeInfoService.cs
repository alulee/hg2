using HGenealogy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGenealogy.Services.Interface
{
    public interface IPedigreeInfoService
    {
        IQueryable<PedigreeInfo> GetAll();
        PedigreeInfo GetById(int id);
        void Insert(PedigreeInfo entity);
        void Update(PedigreeInfo entity);
        void Delete(PedigreeInfo entity);
    }
}