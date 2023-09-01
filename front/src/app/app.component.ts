import { Component } from '@angular/core';
import { UserModel } from './models/user.model';
import { AuthenticationService } from './services/authentication-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user?: UserModel | null;

  constructor(private authService: AuthenticationService) {
      this.authService.user.subscribe(x => this.user = x);
  }

  logout() {
      this.authService.logout();
  }
}
