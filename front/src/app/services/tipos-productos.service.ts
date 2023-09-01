import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TiposProductosService {

  constructor( 
    private http: HttpClient) { 

  }



obtener() {
    return this.http.get(`${environment.apiBase}/tipoproducto`);
}
}
