import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnviosService } from 'src/app/services/envios.service';
import { MensajeService } from 'src/app/services/mensaje.service';

@Component({
  selector: 'app-envios',
  templateUrl: './envios.component.html',
  styleUrls: ['./envios.component.css']
})
export class EnviosComponent implements OnInit {

envios :any[] = [];

  constructor(private envioService: EnviosService, private router: Router, private mensajeService: MensajeService) {
  }
  ngOnInit(): void {
    this.cargarEnvios();
  }

  cargarEnvios(){
    this.mensajeService.cargando();
    this.envioService.obtenerEnvios().subscribe({
      next: (res:any) => { console.log(res); this.envios = res; },
      complete: () => {
        this.mensajeService.finCargando();
      },
      error: (err) => {
        console.log(err);
        this.mensajeService.error();
      }
    });
  }

  eliminar(id){
    this.mensajeService.confirmar('¿Desea eliminar el envio?', () => {
      this.mensajeService.cargando();
      this.envioService.eliminar(id).subscribe({
        next: (res:any) => { 
          console.log(res); 
          this.cargarEnvios();
        },
        complete: () => {
          this.mensajeService.finCargando();
        },
        error: (err) => {
          console.log(err);
          this.mensajeService.error();
        }
      })

    })
  }

  editar(id){
    this.router.navigateByUrl(`/logistica/envios/${id}`);
  }
}
