import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication-service.service';
import { MensajeService } from 'src/app/services/mensaje.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form!: FormGroup;
  loading = false;

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private authService: AuthenticationService,
      private mensajeService: MensajeService
  ) { }

  ngOnInit() {
      this.form = this.formBuilder.group({
          username: ['', Validators.required],
          password: ['', Validators.required]
      });
  }
  login() {

      if (this.form.invalid) {
        this.mensajeService.error("Ingrese todos los campos");
          return;
      }

      this.mensajeService.cargando();
      this.authService.login(this.form.value.username, this.form.value.password)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.router.navigateByUrl("/home");
              },
              error: error => {
                  console.log(error);
                  this.mensajeService.error();
              },
              complete: () => {
                  this.mensajeService.finCargando();
              }
          });
  }
}