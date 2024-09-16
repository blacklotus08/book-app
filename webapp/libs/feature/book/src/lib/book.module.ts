import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';

import { BookComponent } from './components/book.component';

export const bookRoutes: Route[] = [
  {
    path: '',
    component: BookComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'book-listing'
      },
      {
        path: 'book-listing',
        component: BookComponent,
      },
    ]
  },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(bookRoutes),
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    CalendarModule,
    InputTextModule,
    TableModule
  ],
  declarations: [BookComponent],
})
export class BookModule {}
