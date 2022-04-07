using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class VentaDAO : DataContext
    {
        /*
        public IQueryable<ProductoCliente> Select()
        {
            IQueryable<ProductoCliente> vent = db.ProductoCliente.AsQueryable();
            return vent;
        }
        */
        public List<VentaDetailDTO> Select()
        {
            try
            {
                List<VentaDetailDTO> Ventas = new List<VentaDetailDTO>();
                var list = (from v in db.ProductoCliente
                            join c in db.Cliente on v.IDCliente equals c.IDCliente
                            join p in db.Producto on v.IDProducto equals p.IDProducto
                            select new
                            {
                                ventaid = v.IDVenta,
                                clienteId = v.IDCliente,
                                nombrecliente = c.Nombre,
                                productoid = v.IDProducto,
                                descripcion = p.Descripcion,
                                cantidad = v.Cantidad
                            }).OrderBy(x => x.ventaid).ToList();

                foreach (var item in list)
                {
                    VentaDetailDTO dto = new VentaDetailDTO();
                    dto.VentaID = item.ventaid;
                    dto.ClienteID = item.clienteId;
                    dto.NombreCliente = item.nombrecliente;
                    dto.ProductoID = item.productoid;
                    dto.DescripcionProducto = item.descripcion;
                    dto.Cantidad = item.cantidad;
                    Ventas.Add(dto);
                }
                return Ventas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                ProductoCliente vent = db.ProductoCliente.First(x => x.IDVenta == id);
                db.Cliente.DeleteVenta(vent);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(VentaDetailDTO entity)
        {
            try
            {
                ProductoCliente vent = db.ProductoCliente.First(x => x.IDVenta == entity.VentaID);
                vent.IDCliente = entity.ClienteID;
                vent.IDProducto = entity.ProductoID;
                vent.Cantidad = entity.Cantidad;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(VentaDetailDTO entity)
        {
            ProductoCliente vent = new ProductoCliente();
            vent.IDProducto = entity.ProductoID;
            vent.IDCliente = entity.ClienteID;
            vent.Cantidad = entity.Cantidad;
            try
            {
                db.ProductoCliente.Add(vent);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
