using Microsoft.AspNetCore.Mvc;
using ProjSocial.Data;
using ProjSocial.Models;



namespace ProjSocial.Controllers
{ 
    [Route ("Usuario")]
    public class UsuarioController : Controller
    {
       [HttpGet]
       
        public IActionResult Index()
        {
            var dbcontext = new Contexto();
            ViewData["usuarios"] = dbcontext.Usuarios?.Where(prop => prop.Id > 0).ToList();

            return View();
        }

        [HttpPost]
        
        public IActionResult Index(Usuario? usuario)
        {
            var dbcontext = new Contexto();
            dbcontext?.Add(usuario);
            dbcontext?.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // Enviar/postar
       
        public IActionResult Atualizar(Usuario? usuarioNewDados)
        {
            var dbcontext = new Contexto();

            var usuarioDados = dbcontext.Usuarios?.Find(usuarioNewDados?.Id);

            usuarioDados.Nome = usuarioNewDados?.Nome;
            usuarioDados.CPF = usuarioNewDados?.CPF;
            usuarioDados.Cidade = usuarioNewDados?.Cidade;
            usuarioDados.Telefone = usuarioNewDados?.Telefone;
            usuarioDados.DataNasc = usuarioNewDados?.DataNasc;
            usuarioDados.Orientacao = usuarioNewDados?.Orientacao;
            usuarioDados.Email = usuarioNewDados?.Email;
            usuarioDados.Senha = usuarioNewDados?.Senha;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost("Usuario.Id")]
       
        public IActionResult Deletar(Usuario? usuario)
        {
            var dbcontext = new Contexto();

            var usuarioDeletar = dbcontext.Usuarios?.Find(usuario?.Id); //Recebe parâmetro de procura do ID para que no formulário, o usuário o busque pelo índice
            dbcontext?.Remove(usuarioDeletar); //método de remoção 
            dbcontext?.SaveChanges(); //Salvar alterações

            return RedirectToAction("Index");
        }


    }

}