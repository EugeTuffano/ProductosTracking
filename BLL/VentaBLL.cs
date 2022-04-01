﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.DAO;

namespace BLL
{
    public class VentaBLL
    {
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
    }
}