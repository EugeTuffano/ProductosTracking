using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class VentaDTO
    {
        public List<ClienteDetailDTO> Clientes { get; set; }
        public List<ProductoDetailDTO> Productos { get; set; }
    }
}
