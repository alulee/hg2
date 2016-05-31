using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Models;
using HGenealogy.Services.Interface;
using HGenealogy.Data;

namespace HGenealogy.Services.Genealogy
{
    public class GeneMetaService : IGeneMetaService
    {
        private hDatabaseEntities db = new hDatabaseEntities();

        public GenealogyMeta GetGeneMetaByID(string geneID)
        {
            GenealogyMeta result = null;
            if (!(string.IsNullOrEmpty(geneID) || geneID == ""))
            {
                result = db.GenealogyMetas.Find(geneID);

            }

            return result;
        }

        public IList<GenealogyMeta> GetPublicGeneMeta()
        {
            List<GenealogyMeta> myGeneMetaList = new List<GenealogyMeta>();      
            var result = db.GenealogyMetas.Where(x => x.IsPublic == true);
            if (result != null)
            {
                myGeneMetaList.AddRange(result);
            }

            return myGeneMetaList;
        }

        public IList<GenealogyMeta> GetAutorizedGeneMeta(string userID)
        {
            List<GenealogyMeta> myGeneMetaList = new List<GenealogyMeta>();
            var result = (from geneMetaData in db.GenealogyMetas
                          join userGeneMetaData in db.UserGeneMetas
                               on geneMetaData.GID equals userGeneMetaData.GeneMetaID
                          where userGeneMetaData.UserID == userID
                          select geneMetaData).ToList();

            if (result != null)
            {
                myGeneMetaList.AddRange(result);
            }
            return myGeneMetaList;
        }


        public IList<GenealogyMeta> GetPublicOrAutorizedGeneMeta(string userID)
        {            
            List<GenealogyMeta> myGeneMetaList = new List<GenealogyMeta>();

            var result = GetPublicGeneMeta();
            if (result != null)
            {
                myGeneMetaList.AddRange(result);
            }
            result = GetAutorizedGeneMeta(userID);

            if (result != null)
            {
                foreach (var g in result)
                {
                    if (myGeneMetaList.Find(x => x.GID == g.GID) == null)
                    {
                        myGeneMetaList.Add(g);
                    }
                }
            }

            return myGeneMetaList;
        }
    }
}