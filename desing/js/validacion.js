document.getElementById("contactForm").addEventListener("submit", function (event) {
    let valido = true;


    document.getElementById("errorNombre").textContent = "";
    document.getElementById("errorCorreo").textContent = "";
    document.getElementById("errorMensaje").textContent = "";


    const nombre = document.getElementById("nombre").value.trim();
    if (nombre === "") {
        document.getElementById("errorNombre").textContent = "El nombre es obligatorio.";
        valido = false;
    }


    const correo = document.getElementById("correo").value.trim();
    const regexCorreo = /^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$/;
    if (!regexCorreo.test(correo)) {
        document.getElementById("errorCorreo").textContent = "Ingrese un correo válido.";
        valido = false;
    }


    const mensaje = document.getElementById("mensaje").value.trim();
    if (mensaje === "") {
        document.getElementById("errorMensaje").textContent = "El mensaje no puede estar vacío.";
        valido = false;
    }

    if (!valido) {
        event.preventDefault();
    }
});