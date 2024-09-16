import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './components/shell.component';
import { Route, RouterModule } from '@angular/router';
import { LibraryApiModule } from '@webapp/library-api';
import { ToastModule } from 'primeng/toast';

export const shellRoutes: Route[] = [
  {
    path: '',
    component: ShellComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'book'
      },
      {
        path: 'book',
        loadChildren: () =>
          import('@webapp/book').then((m) => m.BookModule)
      },
    ]
  },
  {
    path: '**',
    redirectTo: 'book',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(shellRoutes),
    LibraryApiModule,
    ToastModule
  ],
  declarations: [ShellComponent],
})
export class ShellModule {}
