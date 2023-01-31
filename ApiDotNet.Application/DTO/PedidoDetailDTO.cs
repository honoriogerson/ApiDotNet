using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.DTO
{
    public class PedidoDetailDTO
    {
        public int Id { get; set; }
        public string Cliente { get; set;}
        public string Itens { get; set;}
        public DateTime Date { get; set;}



    }
}
