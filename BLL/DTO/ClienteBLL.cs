using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.DAO;

namespace BLL.DTO
{
    public class ClienteBLL : IBLL<ClienteDetailDTO, ClienteDTO>
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
            return dao.Insert(entity);
        }

        public ClienteDTO Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(ClienteDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
