using ContainRs.Application.Repositories;
using ContainRs.Domain.Models;

namespace ContainRs.Application.UseCases
{
    public class ConsultarClientes
    {
        private readonly IClienteRepository _repository;
        public ConsultarClientes(UnidadeFederativa? estado, IClienteRepository repository)
        {
            Estado = estado;
            _repository = repository;
        }

        public UnidadeFederativa? Estado {  get; }

        public Task<IEnumerable<Cliente>> ExecutarAsync()
        {
            if (Estado is not null)
            {
                return _repository.GetAsync(c => c.Estado == Estado);
            }
            return _repository.GetAsync();
        }
    }
}
