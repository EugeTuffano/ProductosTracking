using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClienteDetailDTO
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Provincia { get; set; }
        public string NombreProvincia { get; set; }
        public int TipoDocumento { get; set; }
        public string NombreTipoDoc { get; set; }
        public int NroDocumento { get; set; }
    }
}
