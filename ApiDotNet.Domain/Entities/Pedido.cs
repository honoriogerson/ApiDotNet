using ApiDotNet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiDotNet.Domain.Entities
{
    public sealed class Pedido
    {
        private Itens itemId;
        private Cliente clienteId;

        public int Id { get; private set; }
        public string NumeroPedido {get; private set; }
        public DateTime Date { get; private set; }
        public int ItemId { get; private set; }
        public int ClienteId { get; private set; }
        //Classes para fazer os relacionamentos 
        public Itens Itens { get; set; }
        public Cliente Cliente { get; set; }

        public Pedido(int itemId, int clienteId) {
            
            Validation(itemId, clienteId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemId"></param>
        /// <param name="clienteId"></param>
        /// <param name="date"></param>
        public Pedido(int id, int itemId, int clienteId)
        {
            DomainValidationException.When(id < 0, "id invalido");
            Id = id;
            Validation(itemId, clienteId);
        }

        //Construtor auxiliar para manter o rastreio da edição
        public void Edit(int id, int itemId, int clienteId)
        {
            DomainValidationException.When(id < 0, "id invalido");
            Id = id;
            Validation(itemId, clienteId);
        }

        public Pedido(Itens itemId, Cliente clienteId)
        {
            this.itemId = itemId;
            this.clienteId = clienteId;
        }

        //Validação adicional para evitar exceptions
        private void Validation(int itemId, int clienteId)
        {
            DomainValidationException.When(itemId < 0, "Produto deve ser informado");
            DomainValidationException.When(clienteId < 0, "Cliente deve ser informado");
            

            ItemId = itemId;
            ClienteId = clienteId;
            Date = DateTime.Now; 
        }
    }
}
