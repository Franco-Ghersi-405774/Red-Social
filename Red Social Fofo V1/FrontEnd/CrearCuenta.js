


$(document).ready(function () {
    $("#crearCuenta").validate({
        rules: {
            inputUsuario: {
                required: true,
                minlength: 3
            },
            inputNombre: {
                required: true,
                minlength: 1
            },
            inputContraseña: {
                required: true,
                minlength: 4
            },
            inputContraseña2: {
                required: true,
                minlength: 4,
                equalTo: "#inputContraseña" // Validación para confirmar la contraseña
            },
            inputEmail: {
                required: true,
                email: true
            }
        },
        messages: {
            inputUsuario: {
                required: "Por favor, ingresa un nombre de usuario",
                minlength: "El nombre de usuario debe tener al menos 3 caracteres"
            },
            inputNombre: {
                required: "Por favor, ingresa tu nombre",
                minlength: "El nombre debe tener al menos 1 carácter"
            },
            inputContraseña: {
                required: "Por favor, ingresa una contraseña",
                minlength: "La contraseña debe tener al menos 4 caracteres"
            },
            inputContraseña2: {
                required: "Por favor, repite la contraseña",
                minlength: "La contraseña debe tener al menos 4 caracteres",
                equalTo: "Las contraseñas deben coincidir"
            },
            inputEmail: {
                required: "Por favor, ingresa tu correo electrónico",
                email: "Ingresa una dirección de correo válida"
            }
        },
        errorClass: "is-invalid",
        validClass: "is-valid",

        submitHandler: function (form) {
            if ($("#crearCuenta").valid()) {
                Grabar();
            }
        }
    });
});

function Grabar() {

    const userr = document.getElementById("inputUsuario").value;
    const namee = document.getElementById("inputNombre").value;
    const emaill = document.getElementById("inputUsuario").value;
    const passwordd = document.getElementById("inputContraseña").value;


    fetch("https://localhost:7214/CrearUsuario", {

        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            usuario1: userr,
            nombre: namee,
            email: emaill,
            contraseña: passwordd

        })
    })
        .then(response => response.json())
        .then(response => {


            localStorage.setItem("User", userr)
            localStorage.setItem("Name", namee)
            localStorage.setItem("Email", emaill)
            localStorage.setItem("Password", passwordd)

            window.location.href = "IniciarSesion.html"
        })

        .catch(error => {
            alert("No se pudo crear el usuario")
        })





}








