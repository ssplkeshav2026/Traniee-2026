import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { Cards } from '../../components/cards/cards';

@Component({
  selector: 'app-up-coming',
  imports: [Cards],
  templateUrl: './up-coming.html',
  styleUrl: './up-coming.css',
})
export class UpComing {
  constructor(private popularMovies: MovieService) { }
  PageCount = 1
  popular = signal<any[]>([]);
  loadMore() {
    this.PageCount++;

    this.popularMovies.getTypeMovies(this.PageCount, 'upcoming')
      .subscribe((res: any) => {

        this.popular.update(prev => [
          ...prev,
          ...res.results
        ]);

      });
  }

  ngOnInit() {
    this.popularMovies.getTypeMovies(this.PageCount, 'upcoming').subscribe((res: any) => {
      this.popular.set(res.results);
    });
  }
}
