using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGenealogy.Data;
using HGenealogy.Data.Repository;

namespace HGenealogy.Services.Interface
{
    public interface IPedigreeMetaService
    {
        IQueryable<PedigreeMeta> GetAll();
        PedigreeMeta GetById(int id);
        void Insert(PedigreeMeta entity);
        void Update(PedigreeMeta entity);
    }
}