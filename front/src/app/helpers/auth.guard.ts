import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication-service.service';

export const AuthGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthenticationService);
  const router = inject(Router);



  const user = authService.userValue;
  if (user) {
      // authorised so return true
      return true;
  }

  // not logged in so redirect to login page with the return url
  router.navigate(['/auth/login']);
  return false;
};
