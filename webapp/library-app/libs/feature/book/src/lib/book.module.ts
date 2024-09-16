import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { bookRoutes } from './lib.routes';

@NgModule({
  imports: [CommonModule, RouterModule.forChild(bookRoutes)],
})
export class BookModule {}
