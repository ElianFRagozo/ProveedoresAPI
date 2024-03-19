public interface IProveedorRepository
{
    Task Agregar(Proveedor proveedor);
    Task Actualizar(Proveedor proveedor);
    Task Eliminar(string id);
    Task<Proveedor> ObtenerPorId(string id);
    Task<List<Proveedor>> ObtenerTodos();
}

public class ProveedorRepository : IProveedorRepository
{
    private readonly IMongoCollection<Proveedor> _proveedores;

    public ProveedorRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ProveedoresDB");
        _proveedores = database.GetCollection<Proveedor>("proveedores");
    }

    public async Task Agregar(Proveedor proveedor)
    {
        await _proveedores.InsertOneAsync(proveedor);
    }

    public async Task Actualizar(Proveedor proveedor)
    {
        await _proveedores.ReplaceOneAsync(p => p.Id == proveedor.Id, proveedor);
    }

    public async Task Eliminar(string id)
    {
        await _proveedores.DeleteOneAsync(p => p.Id == id);
    }

    public async Task<Proveedor> ObtenerPorId(string id)
    {return await _proveedores.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Proveedor>> ObtenerTodos()
    {
        return await _proveedores.Find(p => true).ToListAsync();
    }
}