import { Component, signal } from '@angular/core';
import { HomeTable } from '../../components/home-table/home-table';
import { NavBar } from '../../components/nav-bar/nav-bar';
import { Carousel } from "../../components/carousel/carousel";
import { CardBar } from "../../components/card-bar/card-bar";
import { MovieService } from '../../services/allmovies';

@Component({
  selector: 'app-home',
  imports: [HomeTable, Carousel, CardBar],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  movies: any = signal([]);
  today_tranding:any = signal([])
  tranding_Heading= "Todays special"

  week_tranding:any = signal([])
  week_Heading= "Weeks special"

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getMovies().subscribe((res: any) => {
      this.movies.set(res.results);
    });

    this.movieService.getMoviesByTrand("day").subscribe((res: any) => {
      this.today_tranding.set(res.results);
      // console.log(this.today_tranding())
    })

    this.movieService.getMoviesByTrand("week").subscribe((res: any) => {
      this.week_tranding.set(res.results);
      // console.log(this.today_tranding())
    })
  }
}
