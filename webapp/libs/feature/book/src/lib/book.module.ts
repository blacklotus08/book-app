import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { FloatLabelModule } from 'primeng/floatlabel';

import { BookComponent } from './components/book.component';
import { NewBookComponent } from './components/new-book/new-book.component';

export const bookRoutes: Route[] = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'book-listing',
  },
  {
    path: 'book-listing',
    component: BookComponent,
  },
  {
    path: 'new-book',
    component: NewBookComponent,
  },
  { path: 'details', 
    component: NewBookComponent 
  }
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
    TableModule,
    FloatLabelModule
  ],
  declarations: [BookComponent, NewBookComponent],
})
export class BookModule {}
