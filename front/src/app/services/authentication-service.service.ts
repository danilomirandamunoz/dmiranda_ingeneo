import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { UserModel } from '../models/user.model';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private userSubject: BehaviorSubject<UserModel | null>;
  public user: Observable<UserModel | null>;

  constructor( 
    private router: Router,
    private http: HttpClient) { 
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue() {
    return this.userSubject.value;
}

login(username: string, password: string) {
    return this.http.post<UserModel>(`${environment.apiBase}/usuario/login`, { username, password })
        .pipe(map((user:any) => {
          localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
            return user;
        }));
}

logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.userSubject.next(null);
    this.router.navigate(['/auth/login']);
}

registro(user: UserModel) {
    return this.http.post(`${environment.apiBase}/usuario/registro`, user);
}

}
