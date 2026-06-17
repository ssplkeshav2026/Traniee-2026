import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { PagenotFound } from './pages/pagenot-found/pagenot-found';
import { Movies } from './pages/movies/movies';
import { TvShows } from './pages/tv-shows/tv-shows';
import { NowPlaying } from './pages/now-playing/now-playing';
import { UpComing } from './pages/up-coming/up-coming';
import { TopRated } from './pages/top-rated/top-rated';
import { SearchResults } from './pages/search-results/search-results';
import { AiringToday } from './pages/airing-today/airing-today';
import { OnTv } from './pages/on-tv/on-tv';
import { TopRatedTv } from './pages/top-rated-tv/top-rated-tv';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'home', component: Home },

    { path: 'movies', component: Home },
    { path: 'popular', component: Movies },
    { path: 'now-playing', component: NowPlaying },
    { path: 'search', component: SearchResults },
    { path: 'up-coming', component: UpComing },
    { path: 'top-rated', component: TopRated },


    { path: 'popularTv', component: TvShows },
    { path: 'airing-today', component: AiringToday },
    { path: 'on-tv', component: OnTv },
    { path: 'topRatedTv', component: TopRatedTv },
    

    { path: '**', component: PagenotFound },
];
