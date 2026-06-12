import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { CardBar } from '../../components/card-bar/card-bar';
import { Cards } from '../../components/cards/cards';

@Component({
  selector: 'app-top-rated',
  imports: [Cards],
  templateUrl: './top-rated.html',
  styleUrl: './top-rated.css',
})
export class TopRated {
  constructor(private popularMovies: MovieService) { }
  PageCount = 1
  popular = signal<any[]>([]);
  loadMore() {
    this.PageCount++;

    this.popularMovies.getTypeMovies(this.PageCount, 'top_rated')
      .subscribe((res: any) => {

        this.popular.update(prev => [
          ...prev,
          ...res.results
        ]);

      });
  }

  ngOnInit() {
    this.popularMovies.getTypeMovies(this.PageCount, 'top_rated').subscribe((res: any) => {
      this.popular.set(res.results);
    });
  }
}
