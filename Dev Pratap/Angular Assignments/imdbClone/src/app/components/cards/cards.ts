import { Component, Input, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { single } from 'rxjs';

@Component({
  selector: 'app-cards',
  imports: [],
  templateUrl: './cards.html',
})
export class Cards {
    @Input() movies: any = signal([]);
}
