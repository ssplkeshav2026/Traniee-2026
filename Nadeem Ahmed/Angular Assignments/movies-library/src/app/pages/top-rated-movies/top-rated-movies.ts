import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/movie-service';

@Component({
  selector: 'app-top-rated-movies',
  imports: [],
  templateUrl: './top-rated-movies.html',
  styleUrl: './top-rated-movies.css',
})
export class TopRatedMovies {
  topRatedMovies = signal<any[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.loadMovies();
  }

  loadMovies() {
    this.movieService.getUpcomingMovies(this.currentPage()).subscribe((res: any) => {
      this.topRatedMovies.set(res.results);
      const pages = this.totalPages.set(Math.min(res.total_pages, 500));
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
