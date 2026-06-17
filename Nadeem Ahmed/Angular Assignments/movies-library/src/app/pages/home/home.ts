import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Trending } from '../../services/trending';
import { MovieService } from '../../services/movie-service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  movies: any[] = [];
  trendingMovies = signal<any[]>([]);
  selected: string = 'day';   
constructor(
  private trendingService: Trending
) {}
  
  ngOnInit() {
    this.getTrending();
  }

  getTrending() {
    this.trendingService.getTrending(this.selected)
      .subscribe((res: any) => {
        this.trendingMovies.set(res.results);
      });
  }

  changeType(type: string) {
    this.selected = type;
    this.getTrending();
  }

   
}