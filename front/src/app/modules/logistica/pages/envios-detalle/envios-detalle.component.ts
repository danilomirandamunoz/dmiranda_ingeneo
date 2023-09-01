import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, map } from 'rxjs';
import { generaNumeroFlota, generaNumeroGuia, generaPlacaVehiculo } from 'src/app/helpers/utils';
import { ClientesService } from 'src/app/services/clientes.service';
import { EnviosService } from 'src/app/services/envios.service';
import { LugarEntregaService } from 'src/app/services/lugar-entrega.service';
import { MensajeService } from 'src/app/services/mensaje.service';
import { TipoLogisticaService } from 'src/app/services/tipo-logistica.service';
import { TiposProductosService } from 'src/app/services/tipos-productos.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-envios-detalle',
  templateUrl: './envios-detalle.component.html',
  styleUrls: ['./envios-detalle.component.css']
})
export class EnviosDetalleComponent {
  
  idEnvio;
  form: FormGroup;
  lugarEntrega:any[]=[];
  clientes:any[]=[];
  tiposProducto:any[]=[];
  tipoLogistica :any[]=[];

  constructor(private route: ActivatedRoute, 
    private envioService: EnviosService,
    private clienteService: ClientesService,
    private lugarEntregaService: LugarEntregaService,
    private tipoLogisticaService: TipoLogisticaService,
    private tipoProductoService: TiposProductosService,
    private mensajeService: MensajeService,
    private router: Router

    ) {
      this.crearFormulario();
      this.cargarListas();
      this.route.params.subscribe(params => {
          console.log(params);
          this.idEnvio = Number(params['id']);
          if(this.idEnvio>0){
            this.cargarFormulario();
          }
          
      });

      
  }
  cargarListas() {

      this.clienteService.obtener().subscribe((res:any) => { console.log(res); this.clientes = res; });
      //this.lugarEntregaService.obtener().subscribe((res:any) => { console.log(res); this.lugarEntrega = res; });
      this.tipoLogisticaService.obtener().subscribe((res:any) => { console.log(res); this.tipoLogistica = res; });
      this.tipoProductoService.obtener().subscribe((res:any) => { console.log(res); this.tiposProducto = res; });
    

  }
  cargarFormulario() {
    this.mensajeService.cargando();
    this.envioService.obtenerEnvioPorId(this.idEnvio)
    .subscribe(
      {
        next: (res:any) => { 
          console.log("cliente",res);
          this.lugarEntregaService.obtenerPorId(res.lugarEntregaId).subscribe((res:any) => 
          { 
            let lugar = res;
            this.form.patchValue({
              tipoLogisticaId: res.tipoLogisticaId
            });

            this.cargarLugarEntrega(res.tipoLogisticaId);

          });

          this.form.patchValue({
            clienteId: res.clienteId,
            tipoProductoId: res.tipoProductoId,
            cantidadProducto : res.cantidadProducto,
            fechaRegistro : this.crearFormatoFecha(res.fechaRegistro),
            fechaEntrega : this.crearFormatoFecha(res.fechaEntrega),
            lugarEntregaId : res.lugarEntregaId,
            precioEnvio : res.precioEnvio,
            numeroVehiculoFlota : res.numeroVehiculoFlota,
            numeroGuia : res.numeroGuia
          });
          console.log(this.form.value);

        },
        complete: () => {
          this.mensajeService.finCargando();
        },
        error: (err) => {
          console.log(err);
          this.mensajeService.error();
        }
      }

    )
  }

  crearFormulario() {
      this.form = new FormGroup({
        clienteId: new FormControl(0),
        tipoProductoId: new FormControl(0),
        cantidadProducto : new FormControl(""),
        fechaRegistro : new FormControl(),
        fechaEntrega : new FormControl(),
        tipoLogisticaId: new FormControl(0),
        lugarEntregaId : new FormControl(0),
        precioEnvio : new FormControl(0),
        numeroVehiculoFlota : new FormControl(''),
        numeroGuia : new FormControl('')
      });
  }

  crearFormatoFecha(fecha: string): string {

    const date: Date = new Date(fecha);

    if(date.getFullYear() <= 1900){
      return "";
    }
    const año = date.getFullYear().toString();
    const mes = (date.getMonth() + 1) <= 9 ? '0' + (date.getMonth() + 1).toString() : (date.getMonth() + 1).toString();
    const dia = date.getDate() <= 9 ? '0' + date.getDate().toString() : date.getDate().toString();
    return año + '-' + mes + '-' + dia;
  }

  cargarLugarEntrega(id){

    this.lugarEntregaService.obtenerPorIdTipoLogistica(id)
    .subscribe((res:any) => {
      this.lugarEntrega = res;
    })
  }

  guardar(){
    let envio = this.form.value;
    envio.id = this.idEnvio;
    if(this.idEnvio==0)
    {
      envio.numeroVehiculoFlota = environment.tipoLogistica.Maritima == this.form.value.tipoLogisticaId ? generaNumeroFlota() : generaPlacaVehiculo();
      envio.numeroGuia = generaNumeroGuia();
    }

    if(envio.cantidadProducto>10)
    {
      let porc = environment.tipoLogistica.Maritima == this.form.value.tipoLogisticaId? 5 : 10; 
      envio.precioEnvio = Math.floor(envio.precioEnvio - (envio.precioEnvio * porc / 100));
    }
    this.mensajeService.cargando();
    console.log(envio);
    
    this.envioService.guardar(envio).subscribe({
      next: (res:any) => { 
        console.log(res); 
        this.mensajeService.exito();
        this.router.navigateByUrl(`/logistica/envios`);
      },
      complete: () => {
        this.mensajeService.finCargando();
      },
      error: (err) => {
        console.log(err);
        this.mensajeService.error();
      }
    })
  }

}
