using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class ProvinciaDAO : DataContext
    {
        public List<ProvinciaDetailDTO> Select()
        {
            try
            {
                List<ProvinciaDetailDTO> Provincias = new List<ProvinciaDetailDTO>();
                var list = (from p in db.Provincia
                            select new
                            {
                                idprovincia = p.IDProvincia,
                                descripcion = p.Descripcion
                            }).OrderBy(x => x.idprovincia).ToList();

                foreach (var item in list)
                {
                    ProvinciaDetailDTO dto = new ProvinciaDetailDTO();
                    dto.ProvinciaID = item.idprovincia;
                    dto.Descripcion = item.descripcion;
                    Provincias.Add(dto);
                }
                return Provincias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
