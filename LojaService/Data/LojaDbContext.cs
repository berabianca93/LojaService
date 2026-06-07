using LojaService.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaService.Data;

public class LojaDbContext(DbContextOptions<LojaDbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos => Set<Produto>();
}
