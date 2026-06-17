import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';

@Component({
  selector: 'app-carousel',
  imports: [],
  templateUrl: './carousel.html',
  styleUrl: './carousel.css',
})
export class Carousel {
  movies: any = signal([]);

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getMovies().subscribe((res: any) => {
      this.movies.set(res.results);
    });
  }
}
