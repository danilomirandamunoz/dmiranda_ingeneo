import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AuthGuard } from './helpers/auth.guard';

const authModule = () => import('./modules/auth/auth.module').then(x => x.AuthModule);
const logisticaModule = () => import('./modules/logistica/logistica.module').then(x => x.LogisticaModule);

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'auth', loadChildren: authModule },
  { path: 'logistica', loadChildren: logisticaModule, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
