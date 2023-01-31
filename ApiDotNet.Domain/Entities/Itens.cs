using ApiDotNet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Itens
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<Pedido> Pedidos { get; set; }
        public Itens(string name, decimal price) {

            Validation(name, price);
            Pedidos = new List<Pedido>();
        }

        /// <summary>
        /// Contrutor para editar (PUT)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Itens(int id, string name, decimal price)
        {
            DomainValidationException.When(id < 0, "Id do produto deve ser informado");
            Id = id;
            Validation(name, price);
            Pedidos = new List<Pedido>();
        }

        //Validação adicional para evitar exceptions
        private void Validation(string name, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(price < 0," O preço deve ser informado");

            Name = name;
            Price = price;
        }
    }
}
