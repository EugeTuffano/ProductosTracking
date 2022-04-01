using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class VentaDAO : DataContext
    {
        public IQueryable<ProductoCliente> Select()
        {
            IQueryable<ProductoCliente> vent = db.ProductoCliente.AsQueryable();
            return vent;
        }

    }
}
