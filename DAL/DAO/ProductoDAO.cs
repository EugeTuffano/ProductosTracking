using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProductoDAO : DataContext
    {
        public IQueryable<Producto> Select()
        {
            IQueryable<Producto> pro = db.Producto.AsQueryable();
            return pro;
        }
    }
}
