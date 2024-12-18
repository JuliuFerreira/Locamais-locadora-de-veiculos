using LocaMais.Data;
using LocaMais.Models;

namespace LocaMais.Repositorio
{

    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            _bancoContext.Cliente.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            _bancoContext.Cliente.Update(cliente);
            _bancoContext.SaveChanges(true);
            return cliente;
        }

        public Cliente BuscarPorId(int id)
        {
            var cliente = _bancoContext.Cliente.FirstOrDefault(x => x.Id == id);
            return cliente;
        }

        public List<Cliente> ListarClientes()
        {
            return _bancoContext.Cliente.ToList();
        }


    }
}
