import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication-service.service';
import { MensajeService } from 'src/app/services/mensaje.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css'],
})
export class RegistroComponent {
  form: FormGroup;

  constructor(
    private mensajeService: MensajeService,
    private authService: AuthenticationService
  ) {
    this.crearFormulario();
  }
  crearFormulario() {
    this.form = new FormGroup({
      nombre: new FormControl('', Validators.required),
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  registro() {
    if (this.form.valid) {
      this.mensajeService.cargando();
      this.authService.registro(this.form.value).subscribe({
        next: (res: any) => {
          this.mensajeService.exito('Registro exitoso');
          this.form.reset();
        },
        error: (err) => {
          console.log(err);
          this.mensajeService.error();
        }
      });
    } else {
      this.mensajeService.error('Ingrese todos los campos');
    }
  }
}
