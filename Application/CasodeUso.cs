namespace Application;

public interface ICrearProveedorUseCase
{
    Task<Proveedor> Ejecutar(CrearProveedorCommand command);
}

public interface IActualizarProveedorUseCase
{
    Task<Proveedor> Ejecutar(ActualizarProveedorCommand command);
}

public interface IEliminarProveedorUseCase
{
    Task Ejecutar(EliminarProveedorCommand command);
}

public interface IObtenerProveedorUseCase
{
    Task<Proveedor> Ejecutar(ObtenerProveedorCommand command);
}

public interface IObtenerProveedoresUseCase
{
    Task<List<Proveedor>> Ejecutar(ObtenerProveedoresCommand command);
}