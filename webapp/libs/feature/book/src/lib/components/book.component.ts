import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject, take, tap } from 'rxjs';
import { BookService } from '@webapp/library-api';

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
    //#endregion
  
    constructor(private bookService: BookService) {
      // Load all books
      this.loadBooks();

    }
  
    //#region Private Methods
    private loadBooks() {
      this.bookService.apiBookGet$Response().pipe(
        take(1),
        tap((data:any)=>{
          if (!!data) {
            const response = JSON.parse(data.body);
            const books = response.data?.map((book: any) => ({
              title: book.title,
              author: book.author,
              isbn: book.isbn,
              publishedDate: book.publishedDate,
              id: book.id,
              timestamp: book.tstamp
            }));
            if (books.length > 0) {
              this.campaignListTotalCount$.next(books.length);
              this.campaignList$.next(books);
            }
          }
        })
      ).subscribe();
    }
    //#endregion
}
