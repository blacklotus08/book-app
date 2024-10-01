import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject, take, tap } from 'rxjs';
import { BookService } from '@webapp/library-api';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'lib-book',
  templateUrl: './book.component.html',
  styleUrl: './book.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BookComponent {
    //#region Public Variables
    rows = 20;
    first = 0;
    //#endregion
  
    //#region Observables
    campaignList$  = new BehaviorSubject<any[]>([]);
    campaignListTotalCount$ = new BehaviorSubject<number>(0);
    rows$ = new BehaviorSubject<number>(50);
    headers = new HttpHeaders();
    //#endregion
  
    constructor(private bookService: BookService, private router: Router, private httpClient : HttpClient) {
      // Load all books
      this.loadBooks();
    }
  
    //#region Private Methods
    private loadBooks() {
      // Create params object to include headers
      const apiKey = '193653a3-7965-4f0b-9d98-8420ea03851e';
      const headers = new HttpHeaders().set('X-Api-Token', apiKey);
      const getUrl = 'books';

      this.httpClient
      .get(this.bookService.rootUrl + getUrl, {
        headers,
        observe: 'body',
        responseType: 'json',
      }).pipe(  
        take(1),
        tap((data:any)=>{
          if (!!data) {
            const books = data?.data;
            if (books.length > 0) {
              this.campaignListTotalCount$.next(data?.data.length);
              this.campaignList$.next(data?.data);
            }
          }
        })
      ).subscribe();
    }
    //#endregion

    //#region Public Methods
    navigateBookDetails(bookId: string): void {
      console.log(bookId);
      window.open(`/book/details?id=${bookId}`, '_blank');
    }
    //#endregion
}
