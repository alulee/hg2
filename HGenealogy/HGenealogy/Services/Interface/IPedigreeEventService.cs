using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGenealogy.Data;
using HGenealogy.Data.Repository;

namespace HGenealogy.Services.Interface
{
    public interface IPedigreeEventService
    {
        IQueryable<PedigreeEvent> GetAll();
        PedigreeEvent GetById(int id);
        void Insert(PedigreeEvent entity);
        void Update(PedigreeEvent entity);
        void Delete(PedigreeEvent entity);
    }
}