import { Component, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MovieService } from '../../services/movie-service';

@Component({
  selector: 'app-popular-movies',
  //imports: [RouterLink],
  templateUrl: './popular-movies.html',
  styleUrl: './popular-movies.css',
})

export class PopularMovies {
  movies = signal<any[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);

  constructor(private movieService: MovieService) {}

  ngOnInit() {
    this.loadMovies();
  }

  loadMovies() {
    this.movieService.getPopularMovies(this.currentPage()).subscribe((res: any) => {
      this.movies.set(res.results);
      const pages =this.totalPages.set(Math.min(res.total_pages, 500));
      console.log("Pages: ", res.pages)
    });
  }

  nextPage() {
    if (this.currentPage() < this.totalPages()) {
      this.currentPage.set(this.currentPage() + 1);
      this.loadMovies();
    }
  }

  prevPage() {
    if (this.currentPage() > 1) {
      this.currentPage.set(this.currentPage() - 1);
      this.loadMovies();
    }
  }

  goToFirstPage() {
  if (this.currentPage() !== 1) {
    this.currentPage.set(1);
    this.loadMovies();
  }
}

goToLastPage() {
  if (this.currentPage() !== this.totalPages()) {
    this.currentPage.set(this.totalPages());
    this.loadMovies();
  }
}
}
