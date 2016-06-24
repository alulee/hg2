using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGenealogy.Data;
using HGenealogy.Data.Repository;

namespace HGenealogy.Services.Interface
{
    public interface INewsService
    {
        IQueryable<News> GetAll();
        News GetById(int id);
        void Insert(News entity);
        void Update(News entity);
    }
}