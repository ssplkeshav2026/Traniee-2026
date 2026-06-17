import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeTable } from './components/home-table/home-table';
import { Home } from './pages/home/home';
import { NavBar } from './components/nav-bar/nav-bar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavBar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('imdbClone');
}
