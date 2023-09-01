import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class MensajeService {

  constructor() { }

  exito(mensaje = 'procesado correctamente', titulo = 'OK'){    
    Swal.fire({
      icon: 'success',
      title: titulo,
      text: mensaje,
    })  
  }

  error(mensaje = 'Parece que algo salió mal', titulo = 'ERROR'){    
    Swal.fire({
      icon: 'error',
      title: titulo,
      text: mensaje,
    });      
  }


  cargando(mensaje:string = 'Procesando información...', titulo:string = 'Espera'){
    Swal.fire({
      title: titulo,
      html: mensaje,      
      timerProgressBar: true,
      allowOutsideClick: false,
      showConfirmButton:false,
      willOpen: () => {
        Swal.showLoading()
      }
    })
  }

  finCargando(){
    Swal.hideLoading();
    Swal.close();
  }

  confirmar(titulo, callback,  confirmButtonText = 'Continuar' , cancelButtonText = 'Cancelar'){
    Swal.fire({
      title: titulo,
      showCancelButton: true,
      cancelButtonText: cancelButtonText,
      confirmButtonText: confirmButtonText,
    }).then((result) => {
      if(result.isConfirmed){
        
        callback();            
      }
    });
  }

}
