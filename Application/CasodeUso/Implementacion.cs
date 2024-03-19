public class CrearProveedorUseCase : ICrearProveedorUseCase
{
    private readonly IProveedorRepository _proveedorRepository;

    public CrearProveedorUseCase(IProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }

    public async Task<Proveedor> Ejecutar(CrearProveedorCommand command)
    {
        // Validar los datos del proveedor
        // ...

        // Crear el proveedor
        var proveedor = new Proveedor(
            command.NIT,
            command.RazonSocial,
            command.Direccion,
            command.Ciudad,
            command.Departamento,
            command.Correo,
            command.Activo,
            command.FechaCreacion,
            command.NombreContacto,
            command.CorreoContacto);

        await _proveedorRepository.Agregar(proveedor);

        return proveedor;
    }
}
