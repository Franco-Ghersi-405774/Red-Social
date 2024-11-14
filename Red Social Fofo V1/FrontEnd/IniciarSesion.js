
$(document).ready(function () {
    $("#iniciarSesion").validate({
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
        errorClass: "is-invalid", // Clases de Bootstrap para estilos de error
        validClass: "is-valid",   // Clase para estilo válido en verde
        
        submitHandler: function (form) {
            form.submit(); // Envía el formulario si es válido
        }
    });
});





function iniciarSesion() {
    // Obtener los valores de los campos de email y contraseña
    const usuario = document.getElementById("inputUsuario").value;
    const nombre = document.getElementById("inputNombre").value;

    const email = document.getElementById("inputEmail").value;
    const password = document.getElementById("inputContraseña").value;

    // Verificar que los campos no estén vacíos
    if (!email || !password) {
        alert("Por favor, ingresa el email y la contraseña");
        return;
    }

    // Llamar a la API
    fetch("https://localhost:7214/Iniciar Sesion", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            email: email,
            password: password,
        }),
    })
        .then(response => {
            if (response.ok) {

                
                return response.json();
            } else {
                throw new Error("Email o contraseña incorrectos");
            }
        })
        .then(data => {
            // Procesar la respuesta de la API si el inicio de sesión es exitoso
            alert("Inicio de sesión exitoso");
            // Redireccionar a la página principal o guardar el token si es necesario
            // Por ejemplo: window.location.href = "/home";

            localStorage.setItem("User", usuario)
                localStorage.setItem("Name", nombre)
                localStorage.setItem("Email",email)
                localStorage.setItem("Password",password)

                window.location.href = "PrincipalPage.html"

        })
        .catch(error => {
            // Mostrar error si el inicio de sesión falla
            alert(error.message);
        });
}
