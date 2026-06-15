import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router
} from '@angular/router';

import { inject } from '@angular/core';

export const roleGuard:
CanActivateFn =
(route: ActivatedRouteSnapshot) => {

  const router =
    inject(Router);

  const userString =
    localStorage.getItem(
      'user'
    );

  if (!userString) {

    router.navigate(
      ['/login']
    );

    return false;
  }

  const user =
    JSON.parse(userString);

  const allowedRoles =
    route.data['roles'];

  if (
    allowedRoles.includes(
      user.Role.name
    )
  ) {
    return true;
  }

  router.navigate(
    ['/dashboard']
  );

  return false;
};