using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DocumentoDAO : DataContext
    {
        public List<TipoDocumentoDetailDTO> Select()
        {
            try
            {
                List<TipoDocumentoDetailDTO> Documentos = new List<TipoDocumentoDetailDTO>();
                var list = (from d in db.TipoDocumento
                            select new
                            {
                                idtipodoc = d.IDTipoDoc,
                                descripcion = d.Descripcion
                            }).OrderBy(x => x.idtipodoc).ToList();

                foreach (var item in list)
                {
                    TipoDocumentoDetailDTO dto = new TipoDocumentoDetailDTO();
                    dto.IDTipoDoc = item.idtipodoc;
                    dto.Descripcion = item.descripcion;
                    Documentos.Add(dto);
                }
                return Documentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
