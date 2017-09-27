using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Repositorio
    {
        private static Repositorio _repositorio;

        private List<Pessoa> pessoa;

        private List<Noticia> noticia;

        private Repositorio()
        {
            pessoa = new List<Pessoa>();
            noticia = new List<Noticia>();
        }

        public static Repositorio Instance()
        {
            if (_repositorio == null)
            {
                _repositorio = new Repositorio();
            }

            return _repositorio;
        }

        public void InserirPessoa(Pessoa pess)
        {
            pessoa.Add(pess);
        }
        public void InserirNoticia(Noticia not)
        {
            noticia.Add(not);
        }

        public IEnumerable<Pessoa> ListarPessoas()
        {
            return pessoa;
        }
        public IEnumerable<Noticia> ListarNoticias()
        {
            return noticia;
        }

        public Pessoa ListarPessoa(int idpessoa)
        {
            return pessoa.Where(f => f.IDPessoa == idpessoa).First();
        }
        public Noticia ListarNoticia(int idnoticia)
        {
            return noticia.Where(f => f.IDNoticia == idnoticia).First();
        }

        public void ExcluirPessoa(int idpessoa)
        {
            pessoa.Remove(ListarPessoa(idpessoa));
        }
        public void ExcluirNoticia(int idnoticia)
        {
            noticia.Remove(ListarNoticia(idnoticia));
        }

        public void AlterarPessoa(Pessoa pess)
        {
            pessoa.Where(f => f.IDPessoa == pess.IDPessoa)
                   .ToList()
                   .ForEach(s =>
                   {
                       s.NomeCompleto = pess.NomeCompleto;
                       s.Endereco = pess.Endereco;
                       s.Email = pess.Email;
                       s.DataNascimento = pess.DataNascimento;
                       s.Usuario = pess.Usuario;
                       s.Senha = pess.Senha;
                   });
        }
        public void AlterarNoticia(Noticia not)
        {
            noticia.Where(f => f.IDNoticia == not.IDNoticia)
                   .ToList()
                   .ForEach(s =>
                   {
                       s.Titulo = not.Titulo;
                       s.Materia = not.Materia;
                       s.Imagem = not.Imagem;
                       s.DataMateria = not.DataMateria;
                   });
        }
    }
}