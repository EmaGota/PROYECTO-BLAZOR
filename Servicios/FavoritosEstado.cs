namespace BovedaUru.Servicios;

public class FavoritosEstado
{
    private readonly HashSet<int> _favoritos = new();

    public event Action? OnCambio;

    public int Total => _favoritos.Count;

    public bool EsFavorito(int id) => _favoritos.Contains(id);

    public void Alternar(int id)
    {
        if (!_favoritos.Add(id))
            _favoritos.Remove(id);

        OnCambio?.Invoke();
    }
}