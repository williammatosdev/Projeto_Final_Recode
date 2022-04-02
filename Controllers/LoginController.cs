using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroElogin.Data;
using CadastroElogin.Models;
using Microsoft.AspNetCore.Http;

namespace CadastroElogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            using (Context db = new Context())
            {
                return View();
            }
        }

        [HttpPost]

        public IActionResult Logar(Usuario _email, Usuario _senha)
        {
            try
            {
                using (var context = new Context())
                {
                    var usuario = context.clientes.Single(u => u.Email == _email.Email && u.Senha == _senha.Senha);
                   

                    if (usuario != null)
                    {
                        //Mais codigos foram adicionados na startup
                        TempData["Id_usuario"] = usuario.Id_usuario.ToString();
                        TempData["Nome"] = usuario.Nome.ToString();
                        TempData["Email"] = usuario.Email.ToString();

                        return RedirectToAction("Logado");
                    }

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Credenciais", "Email ou senha incorretos");
            }
            return View("Index");
        }

        public ActionResult Logado()
        {
            if (TempData["Id_usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
