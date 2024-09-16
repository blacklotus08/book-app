import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  standalone: true,
  imports: [RouterModule],
  selector: 'la-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [MessageService, DialogService]
})
export class AppComponent {
  title = 'Library App';
}
