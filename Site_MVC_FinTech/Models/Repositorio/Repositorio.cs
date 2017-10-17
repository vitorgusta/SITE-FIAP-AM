using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Repositorio
    {
        /*INSERIR   */
        public static bool InserirPessoa(Pessoa pess)
        {
            using (var ctx = new ClassContext())
            {

                List<Pessoa> pessoa = ctx.Pessoa.Where(p =>
                    p.NomeCompleto.Equals(pess.NomeCompleto, StringComparison.CurrentCultureIgnoreCase) &&
                    p.Usuario.Equals(pess.Usuario, StringComparison.CurrentCultureIgnoreCase)).ToList();

                if (pessoa.Count == 0)
                {
                    ctx.Pessoa.Add(pess);
                    ctx.SaveChanges();

                    return true;
                }

                return false;
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
        public static bool InserirContato(Contato cont)
        {
            using (var ctx = new ClassContext())
            {
                ctx.Contato.Add(cont);
                ctx.SaveChanges();

                return true;
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
            using (var ctx = new ClassContext())
            {
                return ctx.Pessoa.Where(f => f.IDPessoa == idpessoa).First();
            }
        }
        public static Noticia ListarNoticia(int idnoticia)
        {
            using (var ctx = new ClassContext())
            {
                return ctx.Noticia.Where(f => f.IDNoticia == idnoticia).First();
            }
        }
        public static Contato ListarContato(int idcontato)
        {
            using (var ctx = new ClassContext())
            {
                return ctx.Contato.Where(f => f.IDContato == idcontato).First();
            }
        }

        public static Pessoa FindById(string usuario, string senha)
        {
            using (var ctx = new ClassContext())
            {
                return ctx.Pessoa.FirstOrDefault(user =>
                                                user.Usuario.Equals(usuario, StringComparison.CurrentCultureIgnoreCase) &&
                                                user.Senha.Equals(senha, StringComparison.CurrentCultureIgnoreCase)
                                            );
            }

        }

        /*EXCLUIR   */
        public static void ExcluirPessoa(int idpessoa)
        {
            using (var ctx = new ClassContext())
            {
                Pessoa pessoa = ctx.Pessoa.Where(p => p.IDPessoa == idpessoa).First();

                ctx.Pessoa.Remove(pessoa);
                ctx.SaveChanges();
            }
        }
        public static void ExcluirNoticia(int idnoticia)
        {
            using (var ctx = new ClassContext())
            {
                Noticia noticia = ctx.Noticia.Where(n => n.IDNoticia == idnoticia).First();

                ctx.Noticia.Remove(noticia);
                ctx.SaveChanges();
            }
        }
        public static void ExcluirContato(int idcontato)
        {
            using (var ctx = new ClassContext())
            {
                Contato contato = ctx.Contato.Where(c => c.IDContato == idcontato).First();

                ctx.Contato.Remove(contato);
                ctx.SaveChanges();
            }
        }

        /*ALTERAR   */
        public static void AlterarPessoa(Pessoa pess)
        {
            using (var ctx = new ClassContext())
            {
                Pessoa pessoa = ctx.Pessoa.Where(p => p.IDPessoa == pess.IDPessoa).First();

                pessoa.NomeCompleto = pess.NomeCompleto;
                pessoa.Cpf = pess.Cpf;
                pessoa.Email = pess.Email;
                pessoa.Idade = pess.Idade;
                pessoa.Usuario = pess.Usuario;
                pessoa.Senha = pess.Senha;

                ctx.SaveChanges();
            }
        }
        public static void AlterarNoticia(Noticia not)
        {
            using (var ctx = new ClassContext())
            {
                Noticia noticia = ctx.Noticia.Where(n => n.IDNoticia == not.IDNoticia).First();

                noticia.Titulo = not.Titulo;
                noticia.Materia = not.Materia;
                noticia.Image = not.Image;
                noticia.DataMateria = not.DataMateria;

                ctx.SaveChanges();
            }
        }
        public static void AlterarContato(Contato cont)
        {
            using (var ctx = new ClassContext())
            {
                Contato contato = ctx.Contato.Where(c => c.IDContato == cont.IDContato).First();

                contato.NomeContato = cont.NomeContato;
                contato.EmailContato = cont.EmailContato;
                contato.Mensagem = cont.Mensagem;
                contato.DataMensagem = cont.DataMensagem;

                ctx.SaveChanges();
            }
        }

        /*PESQUISAR   */
        public static IEnumerable<Pessoa> Pesquisar(string texto, string combo)
        {

            using (var ctx = new ClassContext())
            {
                List<Pessoa> pessoa = null;
                switch (combo)
                {
                    case "todos":
                        pessoa = ctx.Pessoa.Where(f => f.NomeCompleto.Contains(texto)).OrderBy(x => x.IDPessoa).ToList();
                        break;

                    case "nome":

                        if (texto != "")
                            pessoa = ctx.Pessoa.Where(f => f.NomeCompleto.Contains(texto)).OrderBy(x => x.NomeCompleto).ToList();
                        break;

                    case "cpf":
                        if (texto != "")
                        {
                            long cpf = Convert.ToInt64(texto);

                            if (cpf != 0)
                                pessoa = ctx.Pessoa.Where(f => f.Cpf == cpf).OrderBy(x => x.Cpf).ToList();
                        }
                        break;

                    case "idade":
                        if (texto != "")
                        {
                            int idade = Convert.ToInt32(texto);

                            if (idade != 0)
                                pessoa = ctx.Pessoa.Where(f => f.Idade == idade).OrderBy(x => x.Idade).ToList();
                        }
                        break;
                }
                return pessoa;

            }
        }
    }
}