import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'lib-shell',
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent {}
