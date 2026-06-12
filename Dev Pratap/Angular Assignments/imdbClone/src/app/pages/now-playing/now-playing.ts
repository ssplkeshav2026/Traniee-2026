import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { Cards } from '../../components/cards/cards';

@Component({
  selector: 'app-now-playing',
  imports: [Cards],
  templateUrl: './now-playing.html',
  styleUrl: './now-playing.css',
})
export class NowPlaying {
  constructor(private popularMovies: MovieService) { }
  PageCount = 1
  popular = signal<any[]>([]);
  loadMore() {
    this.PageCount++;

    this.popularMovies.getTypeMovies(this.PageCount,"now_playing")
      .subscribe((res: any) => {

        this.popular.update(prev => [
          ...prev,
          ...res.results 
        ]);

      });
  }

  ngOnInit() {
    this.popularMovies.getTypeMovies(this.PageCount,"now_playing").subscribe((res: any) => {
      this.popular.set(res.results);
    });
  }
}
