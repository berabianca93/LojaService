using LojaService.Models;

namespace LojaService.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto?> ObterPorIdAsync(int id);
    Task<Produto> CriarAsync(Produto produto);
    Task<Produto?> AtualizarAsync(int id, Produto produto);
    Task<bool> RemoverAsync(int id);
}
