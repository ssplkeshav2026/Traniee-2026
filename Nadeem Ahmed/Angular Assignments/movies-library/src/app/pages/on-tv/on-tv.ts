import { Component, signal } from '@angular/core';
import { TvshowsService } from '../../services/tvshows-service';

@Component({
  selector: 'app-on-tv',
  imports: [],
  templateUrl: './on-tv.html',
  styleUrl: './on-tv.css',
})
export class OnTv {
      onTV = signal<any[]>([]);
      currentPage = signal(1);
      totalPages = signal(1);
    
      constructor(private tvService: TvshowsService) { }
    
      ngOnInit() {
        this.loadMovies();
      }
    
      loadMovies() {
        this.tvService.getOnTV(this.currentPage()).subscribe((res: any) => {
          this.onTV.set(res.results);
          console.log(res.results)
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
