using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Models;
using HGenealogy.Services.Interface;
using HGenealogy.Data;
using System.Web.WebPages.Html;
using HGenealogy.Data.Repository;
using LinqKit;

namespace HGenealogy.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;

        public AddressService(
            IRepository<Country> countryRepository,
            IRepository<City> cityRepository
            )
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }
 
        public IList<Country> GetAllCountries()
        {
            return _countryRepository.GetAll().ToList<Country>();
        }

        public IList<string> GetAllStateProvincesByCountryName(string countryName)
        {
            var stateProvinceList = new List<string>();
            if(countryName == "")
               return stateProvinceList;

            int countryId = GetCountryIdByName(countryName);
            if (countryId > 0)
            {
                var result = _cityRepository.GetAll().Where(p => p.CountryId == countryId);
                if (result != null)
                {
                    var namelist = result.GroupBy(x => new { stateProviceName = x.StateProviceName }).Distinct();
                    foreach( var loop in namelist)
                    {
                        stateProvinceList.Add(loop.Key.stateProviceName);
                    }
                }
            }

            return stateProvinceList;
        }

        
        public int GetCountryIdByName(string countryName)
        {             
            var result = _countryRepository.GetAll().Where(p=> p.Name == countryName).FirstOrDefault();

            if(result != null)
                return result.Id;
            else 
                return 0;
        }

        
    }
}