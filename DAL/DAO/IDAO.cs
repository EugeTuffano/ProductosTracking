using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public interface IDAO <T, K> where T : class where K : class
    {
        //T = clase del modelo
        //K = clase del detalle
        List<K> Select();
        bool Insert(T enitity);
        bool Update(T enitity);
        bool Delete(T enitity);
        bool GetBack(int ID);
    }
}