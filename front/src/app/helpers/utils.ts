export function generaNumeroFlota() {
    const letrasIniciales = generarLetrasAleatorias(3);
    const numeros = generarNumerosAleatorios(4);
    const letraFinal = generarLetrasAleatorias(1);
    
    return `${letrasIniciales}${numeros}${letraFinal}`;
  }

export function generaPlacaVehiculo() {
    const letrasIniciales = generarLetrasAleatorias(3);
    const numeros = generarNumerosAleatorios(3);
    
    return `${letrasIniciales}${numeros}`;
  }
  
 function generarLetrasAleatorias(cantidad) {
    const letras = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let resultado = '';
    
    for (let i = 0; i < cantidad; i++) {
      const indice = Math.floor(Math.random() * letras.length);
      resultado += letras.charAt(indice);
    }
    
    return resultado;
  }
  
  function generarNumerosAleatorios(cantidad) {
    let resultado = '';
    
    for (let i = 0; i < cantidad; i++) {
      const numero = Math.floor(Math.random() * 10);
      resultado += numero;
    }
    
    return resultado;
  }

  export function generaNumeroGuia() {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    const timestamp = new Date().getTime().toString();
    const randomChars = Array.from({ length: 6 }, () => chars[Math.floor(Math.random() * chars.length)]).join('');
  
    const resultado = timestamp.slice(-4) + randomChars;
  
    return resultado;
  }