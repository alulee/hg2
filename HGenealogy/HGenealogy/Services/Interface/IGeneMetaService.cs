using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;

namespace HGenealogy.Services.Interface
{
    public interface IGeneMetaService
    {
        GenealogyMeta GetGeneMetaByID(string geneID);
        IList<GenealogyMeta> GetPublicGeneMeta();
        IList<GenealogyMeta> GetAutorizedGeneMeta(string UserID);
        IList<GenealogyMeta> GetPublicOrAutorizedGeneMeta(string UserID);
    }
}