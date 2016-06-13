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
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;

        public AddressService(
            IRepository<Address> addressRepository,
            IRepository<Country> countryRepository,
            IRepository<City> cityRepository
            )
        {
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public Address GetById(int id)
        {
            return _addressRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public Address GetNewAddress()
        {
            var newAddress = new Address
            {                
                Country = "",
                StateProvince = "",
                City = "",
                Address1 = "",
                Address2 = "",
                ZipPostalCode = "",
                ContactName = "",
                ContactEmail = "",
                ContactPhone = "",
                ContactFax = "",
                CustomAttributes = "",
                IsDeleted = false,
                DisplayOrder = 0,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                CreatedWho = "sa",
                UpdatedWho = "sa"
            };
            return newAddress;
        }


        public IQueryable<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public void Insert(Address entity)
        {
            _addressRepository.Create(entity);
            _addressRepository.SaveChanges();
        }
        public void Update(Address entity)
        {
            _addressRepository.Update(entity);
            _addressRepository.SaveChanges();
        }

        public void CommitChanges()
        {            
            _addressRepository.SaveChanges();
        }

        /// <summary>
        /// 取得所有的 國家清單
        /// </summary>
        /// <returns></returns>
        public IList<Country> GetAllCountries()
        {
            return _countryRepository.GetAll().ToList<Country>();
        }

        /// <summary>
        /// 以國家名稱取得 省/州名稱 清單
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public IList<string> GetAllStateProvincesByCountryName(string countryName)
        {
            var stateProvinceList = new List<string>();
            if(countryName == "")
               return stateProvinceList;

            int countryId = GetCountryIdByName(countryName);
            if (countryId > 0)
            {
                var result = _cityRepository.GetAll().Where(p => p.CountryId == countryId).ToList();
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

        /// <summary>
        /// 以省/州名稱取得 城市名稱清單
        /// </summary>
        /// <param name="stateProvinceName"></param>
        /// <returns></returns>
        public IList<City> GetAllCityByStateProvinceName(string stateProvinceName)
        {
            
            if (stateProvinceName == "")
                return null;

            var result = _cityRepository.GetAll()
                            .Where(p => p.StateProviceName.Trim() == stateProvinceName.Trim())
                            .OrderBy(x => x.ZipCode).ToList();

            return result;
        }

        /// <summary>
        /// 以國家名稱取得 國家Id
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
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