using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ClienteDTO
    {
        public List<ClienteDetailDTO> Clientes { get; set; }
        public List<ProvinciaDetailDTO> Provincias { get; set; }
        public List<TipoDocumentoDetailDTO> TipoDocumentos { get; set; }
    }
}
