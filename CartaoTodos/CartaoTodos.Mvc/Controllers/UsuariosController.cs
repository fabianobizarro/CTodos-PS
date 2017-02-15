using CartaoTodos.Mvc.Models;
using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System.Linq;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IApiRestClient _client;

        public UsuariosController(IApiRestClient client)
        {
            _client = client;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = _client.ObterUsuarios();
            return View(usuarios);
        }

        public ActionResult Novo()
        {
            var model = new CadastroUsuarioViewModel();
            model.Perfis = _client.ObterPerfis();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(CadastroUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Usuario.Perfis = model.PerfisUsuario.Select(p => new Perfil() { Id = p }).ToArray();

                _client.AdicionarUsuario(model.Usuario);
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Detalhes(int id)
        {
            var usuario = _client.ObterUsuario(id);

            if (usuario == null)
            {
                // TODO: Usuário não existe
                return RedirectToAction("Index", "Usuarios");
            }
            else
            {
                return View(usuario);
            }
        }
    }
}