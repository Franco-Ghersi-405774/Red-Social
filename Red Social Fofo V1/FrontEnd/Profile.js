
const obtenerDatos = async () => {
    const token = localStorage.getItem('token');

    const response = await fetch('https://localhost:7214/DatosProtegidos', {
        headers: { 'Authorization': `Bearer ${token}` }
    });

    const data = await response.json();
    console.log(data);
};