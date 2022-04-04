using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.DAO
{
    public class ClienteDAO : DataContext
    {
        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool GetBack()
        {
            throw new NotImplementedException();
        }

        public bool Insert(ClienteDetailDTO entity)
        {
            Cliente cli = new Cliente();
            cli.Nombre = entity.Nombre;
            cli.Direccion = entity.Direccion;
            cli.Provincia = entity.Provincia;
            cli.TipoDoc = entity.TipoDocumento;
            cli.NroDoc = entity.NroDocumento;
            try
            {
                db.Cliente.Add(cli);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        public IQueryable<Cliente> Listar()
        {
            IQueryable<Cliente> cli = db.Cliente.AsQueryable();
            return cli;
        }
        */

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public List<ClienteDetailDTO> Select()
        {
            try
            {
                List<ClienteDetailDTO> Clientes = new List<ClienteDetailDTO>();
                var list = (from c in db.Cliente
                            join p in db.Provincia on c.Provincia equals p.IDProvincia
                            join d in db.TipoDocumento on c.TipoDoc equals d.IDTipoDoc
                            select new
                            {
                                clienteId = c.IDCliente,
                                nombre = c.Nombre,
                                direccion = c.Direccion,
                                provincia = p.IDProvincia,
                                nombreprovincia = p.Descripcion,
                                tipodoc = d.IDTipoDoc,
                                nombretipodoc = d.Descripcion,
                                numerodoc = c.NroDoc
                            }).OrderBy(x => x.clienteId).ToList();

                foreach (var item in list)
                {
                    ClienteDetailDTO dto = new ClienteDetailDTO();
                    dto.ClienteID = item.clienteId;
                    dto.Nombre = item.nombre;
                    dto.Direccion = item.direccion;
                    dto.Provincia = item.provincia;
                    dto.NombreProvincia = item.nombreprovincia;
                    dto.TipoDocumento = item.tipodoc;
                    dto.NombreTipoDoc = item.nombretipodoc;
                    dto.NroDocumento = item.numerodoc;
                    Clientes.Add(dto);
                }
                return Clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
