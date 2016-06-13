using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;
using System.Web.WebPages.Html;

namespace HGenealogy.Services.Interface
{
    public interface IAddressService
    {
        IQueryable<Address> GetAll();
        Address GetById(int id);
        void Insert(Address entity);
        void Update(Address entity);
 

        Address GetNewAddress();
        IList<Country> GetAllCountries();
        IList<string> GetAllStateProvincesByCountryName(string countryName);
        IList<City> GetAllCityByStateProvinceName(string stateProvinceName);

        //GenealogyMeta GetGeneMetaByID(string geneID);
        //IList<GenealogyMeta> GetPublicGeneMeta();
        //IList<GenealogyMeta> GetAutorizedGeneMeta(string UserID);
        //IList<GenealogyMeta> GetPublicOrAutorizedGeneMeta(string UserID);
    }
}