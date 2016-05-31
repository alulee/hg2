using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGenealogy.Data.DbContextFactory
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}