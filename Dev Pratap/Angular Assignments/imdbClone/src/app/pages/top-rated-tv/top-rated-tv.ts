import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { Cards } from '../../components/cards/cards';

@Component({
  selector: 'app-top-rated-tv',
  imports: [Cards],
  templateUrl: './top-rated-tv.html',
  styleUrl: './top-rated-tv.css',
})
export class TopRatedTv {
  constructor(private popularMovies: MovieService) { }
    PageCount = 1
    popular = signal<any[]>([]);
    loadMore() {
      this.PageCount++;
  
      this.popularMovies.getTypetv(this.PageCount,'top_rated')
        .subscribe((res: any) => {
  
          this.popular.update(prev => [
            ...prev,
            ...res.results 
          ]);
  
        });
    }
  
    ngOnInit() {
      this.popularMovies.getTypetv(this.PageCount,'top_rated').subscribe((res: any) => {
        this.popular.set(res.results);
      });
    }
}
