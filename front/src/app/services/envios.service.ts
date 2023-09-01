import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnviosService {

  constructor( 
    private http: HttpClient) { 

  }



  obtenerEnvios() {
      return this.http.get(`${environment.apiBase}/envio`);
  }

  obtenerEnvioPorId(id) {
    return this.http.get(`${environment.apiBase}/envio/${id}`);
  }

  guardar(envio: any) {
    if(envio.id>0){
      return this.http.put(`${environment.apiBase}/envio/${envio.id}`, envio);
    }
    else{
      return this.http.post(`${environment.apiBase}/envio`, envio);}

}

  eliminar(id: number) {
    return this.http.delete(`${environment.apiBase}/envio/${id}`);
  }

}