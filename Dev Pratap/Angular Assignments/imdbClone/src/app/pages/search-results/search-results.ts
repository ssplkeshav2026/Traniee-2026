import { Component, Input, Signal, signal } from '@angular/core';
import { Cards } from '../../components/cards/cards';
import { ActivatedRoute, Route } from '@angular/router';
import { MovieService } from '../../services/allmovies';
import { NavBar } from "../../components/nav-bar/nav-bar";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-results',
  imports: [Cards,FormsModule],
  templateUrl: './search-results.html',
  styleUrl: './search-results.css',
})

export class SearchResults {
  constructor(
    public movieService: MovieService,
  ) { }

  content = signal([])
  page = 1
  movieName=""
  update(i:string){
    if (i==="plus"){
      this.page++
        this.getSearch(this.page)
    } 
    if(this.page>=1){
      if (i==="minus") this.page--
      this.getSearch(this.page)
    }
  }

  // movieName = signal(this.movieService.items());
  // movieList = signal(this.movieService.items)

  getData() {

  this.getSearch()
  }

  getSearch(page:number=1){
    this.movieService.getMoviesByName(this.movieName,page).subscribe((res: any) => {
        this.content.set(res.results);
        console.log(this.content())
      })
  }

}
