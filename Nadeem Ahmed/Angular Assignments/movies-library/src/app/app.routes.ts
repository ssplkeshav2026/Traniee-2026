import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { TopRatedMovies } from './pages/top-rated-movies/top-rated-movies';
import { PopularMovies } from './pages/popular-movies/popular-movies';
import { NowPlaying } from './pages/now-playing/now-playing';
import { UpcomingMovies } from './pages/upcoming-movies/upcoming-movies';
import { PopularTvshows } from './pages/popular-tvshows/popular-tvshows';
import { TopRatedTvshows } from './pages/top-rated-tvshows/top-rated-tvshows';
import { OnTv } from './pages/on-tv/on-tv';
import { AiringToday } from './pages/airing-today/airing-today';

export const routes: Routes = [

      { path: '', component: Home },

    { path: 'movies', component: PopularMovies },

    {
        path: 'movies', children: [
            { path: 'top-rated-movies', component: TopRatedMovies },
            { path: 'upcoming-movies', component: UpcomingMovies },
            { path: 'now-playing', component: NowPlaying }
        ]
    },
    { path: 'tv', component: PopularTvshows },

    {
        path: 'tv', children: [
            { path: 'top-rated-shows', component: TopRatedTvshows },
            { path: 'on-the-air', component: OnTv },
            { path: 'airing-today', component: AiringToday }
        ]
    }


];