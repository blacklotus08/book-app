import { Route } from '@angular/router';

export const appRoutes: Route[] = [
    {
        path: '',
        loadChildren: () =>
          import('@webapp/shell').then((m) => m.ShellModule),
    }
];
