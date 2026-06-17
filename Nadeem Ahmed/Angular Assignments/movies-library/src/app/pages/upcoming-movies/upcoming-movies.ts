import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/movie-service';

@Component({
  selector: 'app-upcoming-movies',
  imports: [],
  templateUrl: './upcoming-movies.html',
  styleUrl: './upcoming-movies.css',
})
export class UpcomingMovies {
  upcomingMovies = signal<any[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.loadMovies();
  }

  loadMovies() {
    this.movieService.getUpcomingMovies(this.currentPage()).subscribe((res: any) => {
      this.upcomingMovies.set(res.results);
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
