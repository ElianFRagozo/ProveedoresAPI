[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly ICrearProveedorUseCase _crearProveedorUseCase;
    private readonly IActualizarProveedorUseCase _actualizarProveedorUseCase;
    private readonly IEliminarProveedorUseCase _eliminarProveedorUseCase;
    private readonly IObtenerProveedorUseCase _obtenerProveedorUseCase;
    private readonly IObtenerProveedoresUseCase _obtenerProveedoresUseCase;

    public ProveedoresController(
        ICrearProveedorUseCase crearProveedorUseCase,
        IActualizarProveedorUseCase actualizarProveedorUseCase,
        IEliminarProveedorUseCase eliminarProveedorUseCase,
        IObtenerProveedorUseCase obtenerProveedorUseCase,
        IObtenerProveedoresUseCase obtenerProveedoresUseCase)
    {
        _crearProveedorUseCase = crearProveedorUseCase;
        _actualizarProveedorUseCase = actualizarProveedorUseCase;
        _eliminarProveedorUseCase = eliminarProveedorUseCase;
        _obtenerProveedorUseCase = obtenerProveedorUseCase;
        _obtenerProveedoresUseCase = obtenerProveedoresUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<Proveedor>> Crear([FromBody] CrearProveedorCommandcommand)
    {
        var proveedor = await _crearProveedorUseCase.Ejecutar(command);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = proveedor.Id }, proveedor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Proveedor>> Actualizar(string id, [FromBody] ActualizarProveedorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var proveedor = await _actualizarProveedorUseCase.Ejecutar(command);
        return Ok(proveedor);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Eliminar(string id)
    {
        await _eliminarProveedorUseCase.Ejecutar(new EliminarProveedorCommand(id));
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Proveedor>> ObtenerPorId(string id)
    {
        var proveedor = await _obtenerProveedorUseCase.Ejecutar(new ObtenerProveedorCommand(id));
        if (proveedor == null)
        {
            return NotFound();
        }

        return Ok(proveedor);
    }

    [HttpGet]
    public async Task<ActionResult<List<Proveedor>>> ObtenerTodos()
    {
        var proveedores = await _obtenerProveedoresUseCase.Ejecutar(new ObtenerProveedoresCommand());
        return Ok(proveedores);
    }
}