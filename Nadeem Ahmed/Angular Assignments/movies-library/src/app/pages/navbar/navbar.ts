import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SearchService } from '../../services/search-service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {

  constructor(private searchService: SearchService) {}

search(value: string) {
  this.searchService.setQuery(value);
}
}
