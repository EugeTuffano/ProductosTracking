using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DTO;

namespace BLL
{
    public class VentaBLL
    {
        VentaDAO daoVenta = new VentaDAO();
        ClienteDAO daoCliente = new ClienteDAO();
        ProductoDAO daoProducto = new ProductoDAO();
        
        /*
        public static List<VentaDetailDTO> Select()
        {
            
            VentaDAO ventadao = new VentaDAO();
            ClienteDAO clientedao = new ClienteDAO();
            ProductoDAO productodao = new ProductoDAO();

            var lista = (from v in ventadao.Select()
                         //join c in clientedao.Select() on v.IDCliente equals c.IDCliente
                         //join p in productodao.Select() on v.IDProducto equals p.IDProducto
                         select new VentaDetailDTO
                         {
                             ClienteID = v.IDCliente,
                             //NombreCliente = c.Nombre,
                             ProductoID = v.IDProducto,
                             //DescripcionProducto = p.Descripcion,
                             Cantidad = v.Cantidad
                         }).OrderBy(x => x.ClienteID).ToList();
            return lista;
        }
        */

        public bool Insert(VentaDetailDTO venta)
        {
            return daoVenta.Insert(venta);
        }

        public VentaDTO Select()
        {
            VentaDTO dto = new VentaDTO();
            dto.Ventas = daoVenta.Select();
            dto.Clientes = daoCliente.Select();
            dto.Productos = daoProducto.Select();
            return dto;
        }
    }
}
