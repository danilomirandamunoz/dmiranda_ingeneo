import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LogisticaRoutingModule } from './logistica-routing.module';
import { EnviosComponent } from './pages/envios/envios.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { TiposProductoComponent } from './pages/tipos-producto/tipos-producto.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { EnviosDetalleComponent } from './pages/envios-detalle/envios-detalle.component';
import { BrowserModule } from '@angular/platform-browser';
import { SoloNumerosDirective } from 'src/app/directives/solo-numeros.directive';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EnviosComponent,
    ClientesComponent,
    TiposProductoComponent,
    LayoutComponent,
    EnviosDetalleComponent,
    SoloNumerosDirective
  ],
  imports: [
    CommonModule,
    LogisticaRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class LogisticaModule { }
