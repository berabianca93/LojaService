using LojaService.Data;
using LojaService.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaService.Repositories;

public class ProdutoRepository(LojaDbContext context) : IProdutoRepository
{
    public async Task<IEnumerable<Produto>> ObterTodosAsync() =>
        await context.Produtos.ToListAsync();

    public async Task<Produto?> ObterPorIdAsync(int id) =>
        await context.Produtos.FindAsync(id);

    public async Task<Produto> CriarAsync(Produto produto)
    {
        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto?> AtualizarAsync(int id, Produto produto)
    {
        var existente = await context.Produtos.FindAsync(id);
        if (existente is null) return null;

        existente.Nome = produto.Nome;
        existente.Descricao = produto.Descricao;
        existente.Preco = produto.Preco;
        existente.Estoque = produto.Estoque;

        await context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var produto = await context.Produtos.FindAsync(id);
        if (produto is null) return false;

        context.Produtos.Remove(produto);
        await context.SaveChangesAsync();
        return true;
    }
}
