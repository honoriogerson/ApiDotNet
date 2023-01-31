using ApiDotNet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Cliente
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ICollection<Pedido> Pedidos{ get; set; }
        public Cliente(string name, string email) {

            Validation(name, email);
            Pedidos = new List<Pedido>();
        }

        /// <summary>
        /// Contrutor para editar(PUT)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Cliente(int id, string name, string email)
        {
            DomainValidationException.When(id < 0, "id invalido");
            Id = id;
            Validation(name, email);
            Pedidos = new List<Pedido>();
        }

        //Validação adicional para evitar exceptions
        private void Validation(string name, string email)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(email), "E-mail deve ser informado");

            Name = name;
            Email = email;

        }
    }
}
