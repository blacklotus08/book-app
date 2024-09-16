import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '@webapp/library-api';
import { take, tap } from 'rxjs';

@Component({
  selector: 'lib-new-book',
  templateUrl: './new-book.component.html',
  styleUrl: './new-book.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewBookComponent implements OnInit {
  form!: FormGroup;

  get bookId(): string {
    return this.activatedRoute.snapshot.queryParams['id'] ?? null;
  }

  constructor(
    private fb: FormBuilder, 
    private activatedRoute: ActivatedRoute,
    private bookService: BookService
  ) {
    this.form = this.fb.group({
      title: new FormControl(null, Validators.required),
      author: new FormControl(null, Validators.required),
      isbn: new FormControl(null, Validators.required),
      publishedDate: new FormControl(null, Validators.required)
    });  
  }

  ngOnInit(): void {
      if (!!this.bookId) {
        this.bookService.apiBookIdGet({ id : this.bookId}).pipe(
          take(1),
          tap((data:any)=>{
            if (!!data) {
              const response = JSON.parse(data);
              console.log(response);
              const book = response.data;
              if (!!book) {
                const publishedDate = new Date(book.publishedDate as string);
                this.form.patchValue(book);
                this.form.get('publishedDate')?.patchValue(publishedDate);
              }
            }
          })
        ).subscribe();
      }
  }


  //#region Public Method
  save() {
    console.log('save');
  }
  //#endregion
}
