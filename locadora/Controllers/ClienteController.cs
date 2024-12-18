using LocaMais.Data;
using LocaMais.Models;
using LocaMais.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LocaMais.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index(int id)
        {

            var cliente = _clienteRepositorio.ListarClientes();

            return View(cliente);

        }

        public IActionResult Cadastro()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Cadastro(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente); 
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!"; 
                    return RedirectToAction("Index"); 
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao cadastrar. Verifique os dados informados.";
                    return View(cliente); 
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não foi possível cadastrar o cliente. Tente novamente mais tarde.";
                return View(cliente); 
            }
        }

        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepositorio.BuscarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["MensagemErro"] = "Erro ao atualizar o cliente";
                    return View(cliente);
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não foi possível cadastrar o cliente. Tente novamente mais tarde.";
                return View(cliente);
            }
        }
        public IActionResult Apagar()
        {
            return View();
        }

    }
}
