import { Component, signal } from '@angular/core';
import { TvshowsService } from '../../services/tvshows-service';

@Component({
  selector: 'app-popular-tvshows',
  imports: [],
  templateUrl: './popular-tvshows.html',
  styleUrl: './popular-tvshows.css',
})
export class PopularTvshows {
  popularTVShows = signal<any[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);

  constructor(private tvService: TvshowsService) { }

  ngOnInit() {
    this.loadMovies();
  }

  loadMovies() {
    this.tvService.getPopularTVShows(this.currentPage()).subscribe((res: any) => {
      this.popularTVShows.set(res.results);
      const pages = this.totalPages.set(Math.min(res.total_pages, 500));
      console.log("Pages: ", res.total_pages)
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
