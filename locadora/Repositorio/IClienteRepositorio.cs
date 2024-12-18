using LocaMais.Models;
namespace LocaMais.Repositorio
{
    public interface IClienteRepositorio
    {
        List<Cliente> ListarClientes();


        Cliente Adicionar(Cliente cliente);
        
        Cliente Atualizar(Cliente cliente);

        Cliente BuscarPorId(int id);
    }



}
