// app.js
const formCrearProveedor = document.getElementById("form-crear-proveedor");
const tablaProveedores = document.getElementById("tabla-proveedores");

formCrearProveedor.addEventListener("submit", async (event) => {
    event.preventDefault();

    const nit = document.getElementById("nit").value;
    const razonSocial = document.getElementById("razon-social").value;
    const direccion = document.getElementById("direccion").value;
    const ciudad = document.getElementById("ciudad").value;
    const departamento = document.getElementById("departamento").value;
    const correo = document.getElementById("correo").value;
    const activo = document.getElementById("activo").checked;

    const proveedor = new Proveedor(nit, razonSocial, direccion, ciudad, departamento, correo, activo);
    await crearProveedor(proveedor);

    formCrearProveedor.reset();
});

async function crearProveedor(proveedor) {
    try {
        const response = awaitfetch("api/proveedores", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(proveedor)
        });

        if (!response.ok) {
            throw new Error("Error al crear el proveedor");
        }

        const proveedorCreado = await response.json();
        agregarFilaTabla(proveedorCreado);
    } catch (error) {
        console.error(error);
    }
}

function agregarFilaTabla(proveedor) {
    const fila = tablaProveedores.insertRow();
    fila.innerHTML = `
        <td>${proveedor.nit}</td>
        <td>${proveedor.razonSocial}</td>
        <td>${proveedor.direccion}</td>
        <td>${proveedor.ciudad}</td>
        <td>${proveedor.departamento}</td>
        <td>${proveedor.correo}</td>
        <td>${proveedor.activo ? "Sí" : "No"}</td>
        <td>
            <button onclick="eliminarProveedor('${proveedor.id}')">Eliminar</button>
        </td>
    `;
}

async function eliminarProveedor(id) {
    try {
        const response = await fetch(`api/proveedores/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            throw new Error("Error al eliminar el proveedor");
        }

        eliminarFilaTabla(id);
    } catch (error) {
        console.error(error);
    }
}

function eliminarFilaTabla(id) {
    const filas = tablaProveedores.rows;

    for (let i = 0; i < filas.length; i++) {
        if (filas[i].cells[0].textContent === id) {
            tablaProveedores.deleteRow(i);
            break;
        }
    }
}