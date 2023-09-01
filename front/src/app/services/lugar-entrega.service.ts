import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LugarEntregaService {

  
  constructor( 
    private http: HttpClient) { 

  }



obtener() {
    return this.http.get(`${environment.apiBase}/lugarentrega`);
}

obtenerPorId(id) {
  return this.http.get(`${environment.apiBase}/lugarentrega/${id}`);
}
obtenerPorIdTipoLogistica(id) {
  return this.http.get(`${environment.apiBase}/lugarentrega/obtenerPorTipoLogistica/${id}`);
}
}
