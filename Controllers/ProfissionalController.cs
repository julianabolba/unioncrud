using Microsoft.AspNetCore.Mvc;
using ProjSocial.Data;
using ProjSocial.Models;
using System.Linq;

namespace ProjSocial.Controllers
{   

    [Route("Profissional")]
    public class ProfissionalController : Controller
    {

        [HttpGet]

        public IActionResult Index()
        {
            var dbcontext = new Contexto();
            ViewData["profissionais"]= dbcontext.Profissionais?.Where(prop => prop.Id > 0).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Profissional? profissional)
        {
            var dbcontext = new Contexto();

            dbcontext?.Add(profissional);
            dbcontext?.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost] // Enviar/postar
        public IActionResult Atualizar(Profissional? profissionalNewDados)
        {
            var dbcontext = new Contexto();

            var profissionalDados = dbcontext.Profissionais?.Find(profissionalNewDados?.Id);

            profissionalDados.Nome = profissionalNewDados?.Nome;
            profissionalDados.CNPJ = profissionalNewDados?.CNPJ;
            profissionalDados.Registro = profissionalNewDados?.Registro;
            profissionalDados.Telefone = profissionalNewDados?.Telefone;
            profissionalDados.DataNasc = profissionalNewDados?.DataNasc;
            profissionalDados.Cidade = profissionalNewDados?.Cidade;
            profissionalDados.Especialidade = profissionalNewDados?.Especialidade;
            profissionalDados.Email = profissionalNewDados?.Email;
            profissionalDados.Senha = profissionalNewDados?.Senha;
            
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost("profissional.Id")]
        public IActionResult Deletar(Profissional? profissional)
        {
            var dbcontext = new Contexto();

            var profissionalDeletar = dbcontext.Profissionais?.Find(profissional?.Id); //Recebe parâmetro de procura do ID para que no formulário, o usuário o busque pelo índice
            dbcontext?.Remove(profissionalDeletar); //método de remoção 
            dbcontext?.SaveChanges(); //Salvar alterações

            return RedirectToAction("Index");
        }


    }

}