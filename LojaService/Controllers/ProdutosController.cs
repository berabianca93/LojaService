using LojaService.Models;
using LojaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await repository.ObterTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await repository.ObterPorIdAsync(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Produto produto)
    {
        var criado = await repository.CriarAsync(produto);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Produto produto)
    {
        var atualizado = await repository.AtualizarAsync(id, produto);
        return atualizado is null ? NotFound() : Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await repository.RemoverAsync(id);
        return removido ? NoContent() : NotFound();
    }
}
