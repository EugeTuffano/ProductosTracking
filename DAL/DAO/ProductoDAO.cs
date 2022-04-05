using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.DAO
{
    public class ProductoDAO : DataContext
    {
        /*
        public IQueryable<Producto> Select()
        {
            IQueryable<Producto> pro = db.Producto.AsQueryable();
            return pro;
        }
        */

        public List<ProductoDetailDTO> Select()
        {
            try
            {
                List<ProductoDetailDTO> Productos = new List<ProductoDetailDTO>();
                var list = (from p in db.Producto
                            select new
                            {
                                idproducto = p.IDProducto,
                                descripcion = p.Descripcion
                            }).OrderBy(x => x.idproducto).ToList();

                foreach (var item in list)
                {
                    ProductoDetailDTO dto = new ProductoDetailDTO();
                    dto.ProductoID = item.idproducto;
                    dto.Descripcion = item.descripcion;
                    Productos.Add(dto);
                }
                return Productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
