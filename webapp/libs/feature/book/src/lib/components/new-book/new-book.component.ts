import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'lib-new-book',
  templateUrl: './new-book.component.html',
  styleUrl: './new-book.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewBookComponent {}
