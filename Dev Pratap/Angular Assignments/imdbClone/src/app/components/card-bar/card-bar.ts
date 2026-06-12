import { Component, Input, signal } from '@angular/core';

@Component({
  selector: 'app-card-bar',
  imports: [],
  templateUrl: './card-bar.html',
  styleUrl: './card-bar.css',
})
export class CardBar {
  @Input() movies: any = signal([]);
  @Input() heading: any = signal("");
}
