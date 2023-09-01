import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { LayoutComponent } from './pages/layout/layout.component';

const routes: Routes = [
  {
        path: '', component: LayoutComponent,
        children: [
            { path: 'login', component: LoginComponent  },
            { path: 'registro', component: RegistroComponent }
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
