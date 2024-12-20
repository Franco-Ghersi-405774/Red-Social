
$(document).ready(function () {
    $("#iniciarSesionform").validate({
        rules: {
            usuario_mail: {
                required: true,
                minlength: 3,
            },
            password: {
                required: true,
                minlength: 3
            }
        },
        messages: {
            usuario_mail: {
                required: "Por favor, ingresa un nombre de usuario",
                minlength: "El nombre de usuario debe tener al menos 3 caracteres"
            },
            password: {
                required: "Por favor, ingresa tu nombre",
                minlength: "El nombre debe tener al menos 1 carácter"
            }
        },
        errorClass: "is-invalid",
        validClass: "is-valid",
    });




    $("#iniciarSesionform").on("submit", function (event) {
        if ($(this).valid()) { // Solo llama a iniciarSesion si el formulario es válido
            iniciarSesion(event);
        }
    });
});





function iniciarSesion(event) {

    //para que no recarge la pagina al tocar sumbit
    event.preventDefault();
    // Obtener los valores de los campos de email y contraseña



    const user = document.getElementById("InputUsuario").value;

    const pass = document.getElementById("inputPassword").value;

    // Verificar que los campos no estén vacíos
    if (!user || !pass) {
        alert("Por favor, ingresa el email y la contraseña");
        return;
    }

    debugger

    // Llamar a la API
    fetch("https://localhost:7214/IniciarSesion", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Usuario: user,
            Password: pass,
        }),
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("Usuario o contraseña incorrectosss");
            }
        })
        .then(data => {
            // Procesar la respuesta de la API si el inicio de sesión es exitoso
            alert("Inicio de sesión exitoso");
            // Redireccionar a la página principal o guardar el token si es necesario
            window.location.href = "PrincipalPage.html";
            // Por ejemplo: window.location.href = "/home";
            localStorage.setItem("User", user)
            localStorage.setItem('token', data.token);

        })
        .catch(error => {
            // Mostrar error si el inicio de sesión falla
            alert(error.message);
        });
}
