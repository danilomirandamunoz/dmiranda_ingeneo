import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './pages/layout/layout.component';
import { EnviosComponent } from './pages/envios/envios.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { TiposProductoComponent } from './pages/tipos-producto/tipos-producto.component';
import { EnviosDetalleComponent } from './pages/envios-detalle/envios-detalle.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent,
    children: [
        { path: '', component: LayoutComponent },
        { path: 'envios', component: EnviosComponent },
        { path: 'clientes', component: ClientesComponent },
        { path: 'tiposproducto', component: TiposProductoComponent },
        { path: 'envios/:id', component: EnviosDetalleComponent },
    ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LogisticaRoutingModule { }
