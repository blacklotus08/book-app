import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

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
  
    constructor() {
      // Load all books
      this.loadBooks();

    }
  
    //#region Private Methods
    private loadBooks() {
    }
    //#endregion
}
