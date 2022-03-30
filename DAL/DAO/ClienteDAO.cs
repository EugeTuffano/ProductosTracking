using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Insert(Cliente entity)
        {
            try
            {
                db.Cliente.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Cliente> Select()
        {
            IQueryable<Cliente> cli = db.Cliente.AsQueryable();
            return cli;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
