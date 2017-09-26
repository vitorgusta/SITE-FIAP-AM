using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Repositorio
    {
        private static Repositorio _repositorio;

        private List<Cliente> cliente;

        private Repositorio()
        {
            cliente = new List<Cliente>();
        }

        public static Repositorio Instance()
        {
            if (_repositorio == null)
            {
                _repositorio = new Repositorio();
            }

            return _repositorio;
        }

        public void InserirClinete(Cliente cli)
        {
            cliente.Add(cli);
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return cliente;
        }

        public Cliente ListarCliente(int idcliente)
        {
            return cliente.Where(f => f.IDCliente == idcliente).First();
        }

        public void ExcluirCliente(int idcliente)
        {
            cliente.Remove(ListarCliente(idcliente));
        }

        public void AlterarCliente(Cliente cli)
        {
            cliente.Where(f => f.IDCliente == cli.IDCliente)
                   .ToList()
                   .ForEach(s =>
                   {
                       s.nomeCliente = cli.nomeCliente;
                       s.enderecoCliente = cli.enderecoCliente;
                       s.emailCliente = cli.emailCliente;
                       s.dtNascCLiente = cli.dtNascCLiente;
                   });
        }
    }
}