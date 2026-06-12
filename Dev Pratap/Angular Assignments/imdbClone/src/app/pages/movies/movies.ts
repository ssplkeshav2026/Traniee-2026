import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';
import { Cards } from "../../components/cards/cards";
import { count } from 'rxjs';

@Component({
  selector: 'app-movies',
  imports: [Cards],
  templateUrl: './movies.html',
  styleUrl: './movies.css',
})
export class Movies {
  constructor(private popularMovies: MovieService) { }
  PageCount = 1
  popular = signal<any[]>([]);

  btnClick(update: string) {
    if (update === "plus") {
      this.PageCount++;

      this.popularMovies.getTypeMovies(this.PageCount, "popular")
        .subscribe((res: any) => {
          this.popular.set(res.results)
        });
    }
    if (this.PageCount > 1) {
      if (update === "minus") {

        this.PageCount--;
        this.popularMovies.getTypeMovies(this.PageCount, "popular")
          .subscribe((res: any) => {
            this.popular.set(res.results)
            console.log(this.popular())
          });
      }
    }
  }


  loadMore() {
    this.PageCount++;

    this.popularMovies.getTypeMovies(this.PageCount, "popular")
      .subscribe((res: any) => {

        this.popular.update(prev => [
          ...prev,
          ...res.results
        ]);

      });
  }

  ngOnInit() {
    this.popularMovies.getTypeMovies(this.PageCount, "popular").subscribe((res: any) => {
      this.popular.set(res.results);
    });
  }
}
