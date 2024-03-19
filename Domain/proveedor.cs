public class Proveedor
{
    public string NIT { get; private set; }
    public string RazonSocial { get; private set; }
    public string Direccion { get; private set; }
    public string Ciudad { get; private set; }
    public string Departamento { get; private set; }
    public string Correo { get; private set; }
    public bool Activo { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public string NombreContacto { get; private set; }
    public string CorreoContacto { get; private set; }

    public Proveedor(
        string nit,
        string razonSocial,
        string direccion,
        string ciudad,
        string departamento,
        string correo,
        bool activo,
        DateTime fechaCreacion,
        string nombreContacto,
        string correoContacto)
    {
        // Validar los datos del proveedor
        // ...

        NIT = nit;
        RazonSocial = razonSocial;
        Direccion = direccion;
        Ciudad = ciudad;
        Departamento = departamento;
        Correo = correo;
        Activo = activo;
        FechaCreacion = fechaCreacion;
        NombreContacto = nombreContacto;
        CorreoContacto = correoContacto;
    }

}