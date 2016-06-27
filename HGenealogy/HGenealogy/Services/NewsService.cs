using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using HGenealogy.Services.Interface;
using LinqKit;
using HGenealogy.Models.News;

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

        public List<News> GetNewsList(NewsQueryModel queryModel)
        {
            var filter = PredicateBuilder.True<News>();
            if (!string.IsNullOrEmpty(queryModel.Title))
                filter = filter.And(p => p.Title.Contains(queryModel.Title));

            //var query = _pedigreeMetaRepository.GetAll().Where(filter.Compile());
            var query = _newsRepository.GetRows(filter);

            var result = query.ToList();
            return result;
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