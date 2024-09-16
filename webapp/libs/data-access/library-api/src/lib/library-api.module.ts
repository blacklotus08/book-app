import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiModule } from './api/api.module';

@NgModule({
  imports: [
    CommonModule,
    ApiModule.forRoot({ rootUrl: 'api' })
  ],
})
export class LibraryApiModule {}
