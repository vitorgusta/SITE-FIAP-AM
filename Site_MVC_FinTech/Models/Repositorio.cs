using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Repositorio
    {
        /*INSERIR   */
        public static void InserirPessoa(Pessoa pess)
        {
            using (var ctx = new ClassContext())
            {
                ctx.Pessoa.Add(pess);
                ctx.SaveChanges();

            }
        }
        public static void InserirNoticia(Noticia not)
        {
            using (var ctx = new ClassContext())
            {
                ctx.Noticia.Add(not);
                ctx.SaveChanges();
            }
        }
        public static void InserirContato(Contato cont)
        {
            using (var ctx = new ClassContext())
            {
                ctx.Contato.Add(cont);
                ctx.SaveChanges();
            }
        }

        /*LISTAR TODOS   */
        public static IEnumerable<Pessoa> ListarPessoas()
        {
            var ctx = new ClassContext();

            return ctx.Pessoa;
        }
        public static IEnumerable<Noticia> ListarNoticias()
        {
            var ctx = new ClassContext();

            return ctx.Noticia;
        }
        public static IEnumerable<Contato> ListarContatos()
        {
            var ctx = new ClassContext();

            return ctx.Contato;
        }

        /*LISTAR   */
        public static Pessoa ListarPessoa(int idpessoa)
        {
            var ctx = new ClassContext();

            return ctx.Pessoa.Where(f => f.IDPessoa == idpessoa).First();
        }
        public static Noticia ListarNoticia(int idnoticia)
        {
            var ctx = new ClassContext();

            return ctx.Noticia.Where(f => f.IDNoticia == idnoticia).First();
        }
        public static Contato ListarContato(int idcontato)
        {
            var ctx = new ClassContext();

            return ctx.Contato.Where(f => f.IDContato == idcontato).First();
        }

        /*EXCLUIR   */
        public static void ExcluirPessoa(int idpessoa)
        {
            using (var ctx = new ClassContext())
            {
                ctx.Pessoa.Remove(ListarPessoa(idpessoa));
                ctx.SaveChanges();
            }
        }
        public static void ExcluirNoticia(int id)
        {
            var ctx = new ClassContext();

            ctx.Noticia.Remove(ListarNoticia(id));
            ctx.SaveChanges();
        }
        public static void ExcluirContato(int id)
        {
            var ctx = new ClassContext();

            ctx.Contato.Remove(ListarContato(id));
            ctx.SaveChanges();
        }

        /*ALTERAR   */
        public static void AlterarPessoa(Pessoa pess)
        {
            var ctx = new ClassContext();

            ctx.Pessoa.Where(f => f.IDPessoa == pess.IDPessoa)
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

            ctx.SaveChanges();
        }
        public static void AlterarNoticia(Noticia not)
        {
            var ctx = new ClassContext();

            ctx.Noticia.Where(f => f.IDNoticia == not.IDNoticia)
                   .ToList()
                   .ForEach(s =>
                   {
                       s.Titulo = not.Titulo;
                       s.Materia = not.Materia;
                       s.Imagem = not.Imagem;
                       s.DataMateria = not.DataMateria;
                   });
        }
        public static void AlterarContato(Contato cont)
        {
            var ctx = new ClassContext();

            ctx.Contato.Where(f => f.IDContato == cont.IDContato)
                   .ToList()
                   .ForEach(s =>
                   {
                       s.NomeContato = cont.NomeContato;
                       s.EmailContato = cont.EmailContato;
                       s.Mensagem = cont.Mensagem;
                       s.DataMensagem = cont.DataMensagem;
                   });
        }
    }
}