import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Book, BookService, BookWithId } from '@webapp/library-api';
import { MessageService } from 'primeng/api';
import { take, tap } from 'rxjs';

@Component({
  selector: 'lib-new-book',
  templateUrl: './new-book.component.html',
  styleUrl: './new-book.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewBookComponent implements OnInit {
  form!: FormGroup;

  get bookId(): number {
    return this.activatedRoute.snapshot.queryParams['id'] ?? null;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('X-Api-Token', '193653a3-7965-4f0b-9d98-8420ea03851e');
  }

  constructor(
    private fb: FormBuilder, 
    private activatedRoute: ActivatedRoute,
    private bookService: BookService,
    private messageService: MessageService,
    private httpClient: HttpClient
  ) {
    const now = new Date();
    this.form = this.fb.group({
      title: new FormControl(null, Validators.required),
      author: new FormControl(null, Validators.required),
      isbn: new FormControl(null, Validators.required),
      publishedDate: new FormControl(now.toLocaleDateString())
    });  
  }

  ngOnInit(): void {
      if (!!this.bookId) {
        const getUrl = `book/${this.bookId}`;
        this.httpClient
        .get(this.bookService.rootUrl + getUrl, {
          headers : this.headers,
          observe: 'body',
          responseType: 'json',
        }).pipe(  
          take(1),
          tap((data:any)=>{
            if (!!data) {
              const book = data?.data;
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
    if (this.form.valid) {
      const payload = {
        ...this.form.value,
        id: this.bookId,
        publishedDate: new Date(this.form.get('publishedDate')?.value)
      } as BookWithId;
      if (this.bookId) {
        // Update Book
        const getUrl = `book/${this.bookId}`;
        this.httpClient
        .put(this.bookService.rootUrl + getUrl, payload, {
          headers : this.headers,
          observe: 'body',
          responseType: 'json',
        }).pipe(  
          take(1),
          tap((response:any)=>{
            if (!!response) {
              if (response.isSuccess) {
                this.messageService.add({
                  severity: 'success',
                  summary: 'Success',
                  detail: 'Record successfully updated',
                  life: 6000,
                });
              } else {
                this.messageService.add({
                  severity: 'error',
                  summary: 'Error',
                  detail: 'Error attempting to add book',
                  life: 6000,
                });
              }
            }
          })
        ).subscribe();
      } else {
        // Add New Book
        const getUrl = `book`;
        this.httpClient
        .post(this.bookService.rootUrl + getUrl, payload, {
          headers : this.headers,
          observe: 'body',
          responseType: 'json',
        }).pipe(  
          take(1),
          tap((response:any)=>{
            if (!!response) {
              if (response.isSuccess) {
                this.messageService.add({
                  severity: 'success',
                  summary: 'Success',
                  detail: 'Record successfully added',
                  life: 6000,
                });
              } else {
                this.messageService.add({
                  severity: 'error',
                  summary: 'Error',
                  detail: 'Error attempting to add book',
                  life: 6000,
                });
              }
            }
          })
        ).subscribe();
      }
      this.form.markAsPristine();
    } else {
      this.validateAllFormFields(this.form);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'The form may contain one or more errors. Please check all fields and fix to continue with submission',
        life: 6000,
      });
    }
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      } else if (control instanceof FormArray) {
        (control as FormArray).controls.forEach((control) => {
          if (control instanceof FormGroup) {
            this.validateAllFormFields(control as FormGroup);
          }
        });
      }
    });
  }  
  //#endregion
}
