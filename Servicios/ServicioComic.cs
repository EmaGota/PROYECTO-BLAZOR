using BovedaUru.Components.Modelo;
using BovedaUru.Datos;
using Microsoft.EntityFrameworkCore;

namespace BovedaUru.Servicios;

public class ComicServicio
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ComicServicio(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<List<Comic>> ObtenerTodosAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Comics.AsNoTracking().OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<Comic?> ObtenerPorIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Comics.AsNoTracking()
            .Include(c => c.Enlaces)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ResultadoPaginado<Comic>> BuscarAsync(string? texto, int pagina, int tamano)
    {
        await using var db = await _factory.CreateDbContextAsync();

        var consulta = db.Comics.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(texto))
        {
            var t = texto.Trim().ToLower();
            consulta = consulta.Where(c =>
                c.Titulo.ToLower().Contains(t) ||
                c.Personaje.ToLower().Contains(t) ||
                c.Grupo.ToLower().Contains(t) ||
                c.Editorial.ToLower().Contains(t));
        }

        var total = await consulta.CountAsync();

        var items = await consulta
            .OrderBy(c => c.Titulo)
            .Skip((pagina - 1) * tamano)
            .Take(tamano)
            .ToListAsync();

        return new ResultadoPaginado<Comic>(items, total, pagina, tamano);
    }

    public async Task CrearAsync(Comic comic)
    {
        await using var db = await _factory.CreateDbContextAsync();

        comic.Id = 0;
        comic.Enlaces.RemoveAll(e => string.IsNullOrWhiteSpace(e.Url));
        db.Comics.Add(comic);

        await db.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Comic comic)
    {
        await using var db = await _factory.CreateDbContextAsync();

        var existente = await db.Comics.Include(c => c.Enlaces)
            .FirstAsync(c => c.Id == comic.Id);

        db.Entry(existente).CurrentValues.SetValues(comic);

        existente.Enlaces.Clear();
        foreach (var e in comic.Enlaces.Where(e => !string.IsNullOrWhiteSpace(e.Url)))
            existente.Enlaces.Add(new EnlacesComic { Nombre = e.Nombre, Url = e.Url });

        await db.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();

        var comic = await db.Comics.FindAsync(id);
        if (comic is null) return;

        db.Comics.Remove(comic);   // los enlaces se borran en cascada
        await db.SaveChangesAsync();
    }
}