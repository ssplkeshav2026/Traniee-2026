import { Component, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { MovieService } from '../../services/allmovies';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav-bar',
  imports: [RouterLink, FormsModule],
  templateUrl: './nav-bar.html',
  styleUrl: './nav-bar.css',
})
export class NavBar {
  constructor(private movie: MovieService, private router: Router, private apiServices: MovieService) { }
  pageName = true
  pagechange() {
    this.router.navigate(["/"])
  }

  getmovie() {
    this.router.navigate(['/search']);
  }
}
