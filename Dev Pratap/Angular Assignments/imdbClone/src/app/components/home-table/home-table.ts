import { Component, signal } from '@angular/core';
import { MovieService } from '../../services/allmovies';

@Component({
  selector: 'app-home-table',
  imports: [],
  templateUrl: './home-table.html',
  styleUrl: './home-table.css',
})
export class HomeTable {
  movies: any = signal([]);
  page:number = 1

  constructor(private movieService: MovieService) {}

  isDisplyed = true;
  getData(pageUpdate:string,pageNumber:number=this.page){
    if(pageUpdate === "minus") this.page --
    if(pageUpdate === "plus") this.page ++

    this.movieService.getMovies(this.page).subscribe((res: any) => {
      this.movies.set(res.results);
      console.log(this.movies())
    });
  }
  
  
  ngOnInit() {
    this.movieService.getMovies(this.page).subscribe((res: any) => {
      this.movies.set(res.results);
      // console.log(this.movies())
    });
  }
}
