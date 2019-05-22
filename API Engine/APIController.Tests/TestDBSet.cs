using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIController.Tests
{
    public class TestDBSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
    {

    }
}
