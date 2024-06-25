import { CanActivateFn } from '@angular/router';

export const userGuard: CanActivateFn = (route, state) => {
  if (typeof localStorage !== 'undefined') {
    const token = localStorage.getItem('ACCESS_TOKEN');
    if (token) {
      return true;
    }
  }

  console.log('There is no current user connected');

  if (typeof window !== 'undefined') {
    window.alert('Login please');
  }

  return false;
};
