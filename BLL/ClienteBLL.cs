using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.DAO;

namespace BLL
{
    public class ClienteBLL
    {
        ClienteDAO daoCliente = new ClienteDAO();
        ProvinciaDAO daoProvincia = new ProvinciaDAO();
        DocumentoDAO daoDocumento = new DocumentoDAO();

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ClienteDetailDTO cliente)
        {
            return daoCliente.Insert(cliente);
        }

        /*
        public static List<ClienteDetailDTO> Listar()
        {
            ClienteDAO dao = new ClienteDAO();
            var lista = (from c in dao.Listar()
                         select new ClienteDetailDTO
                         {
                             ClienteID = c.IDCliente,
                             Nombre = c.Nombre,
                             Direccion = c.Direccion,
                             Provincia = c.Provincia,
                             TipoDocumento = c.TipoDoc,
                             NroDocumento = c.NroDoc
                         }).OrderBy(x => x.ClienteID).ToList();

            return lista;
        }
        */
        

        public ClienteDTO Select()
        {
            ClienteDTO dto = new ClienteDTO();
            dto.TipoDocumentos = daoDocumento.Select();
            dto.Clientes = daoCliente.Select();
            dto.Provincias = daoProvincia.Select();
            return dto;
        }

        public bool Update(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
