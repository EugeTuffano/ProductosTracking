using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL;
using DAL.DAO;

namespace BLL.DTO
{
    public class ClienteBLL
    {
        ClienteDAO dao = new ClienteDAO();
        public bool Delete(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public static List<ClienteDetailDTO> Select()
        {
            ClienteDAO dao = new ClienteDAO();
            var lista = (from c in dao.Select()
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

        public bool Update(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
