using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VentaDTO
    {
        public List<VentaDetailDTO> Ventas { get; set; }
        public List<ClienteDetailDTO> Clientes { get; set; }
        public List<ProductoDetailDTO> Productos { get; set; }
    }
}
