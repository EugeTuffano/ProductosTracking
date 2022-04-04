using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VentaDetailDTO
    {
        
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public int ProductoID { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
