using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using HGenealogy.Models.PedigreeMeta;
using LinqKit;

namespace HGenealogy.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _newsRepository;

        public NewsService(
            IRepository<News> newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public IQueryable<News> GetAll()
        {
            return _newsRepository.GetAll();
        }

        public News GetById(int id)
        {
            return _newsRepository.GetAll().Where(p => p.Id == id)
                                          .FirstOrDefault();
        }

        public void Insert(News entity)
        {
            _newsRepository.Create(entity);
            _newsRepository.SaveChanges();
        }
        public void Update(News entity)
        {
            _newsRepository.Update(entity);
            _newsRepository.SaveChanges();
        }
    }
}