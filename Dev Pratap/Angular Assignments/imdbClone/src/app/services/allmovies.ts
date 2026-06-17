import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class MovieService {


  constructor(private http: HttpClient) { }

  getMovies(page: number = 1) {
    let url = environment.baseApiUrl + `/discover/movie?include_adult=false&include_video=false&language=en-US&page=${page}&sort_by=popularity.desc`;
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });

    return this.http.get(url, { headers });
  }

  
  getTypeMovies(page: number = 1, MovieType:string) {
    type MovieType = 'popular' | 'now_playing' | 'top_rated' | 'upcoming';
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });
    return this.http.get(
      `${environment.baseApiUrl}/movie/${MovieType}?page=${page}`,
      // `${environment.apiUrl}/movie/now_playing?api_key=${environment.apiKey}&page=${page}`
      {headers},
    );
  }

  getCategoriesMovies(Categories: string) {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });
    return this.http.get(
      `${environment.baseApiUrl}/genre/movie/list`,
      {headers},
    );
  }

  getMoviesByName(movieName: string|null,page:number) {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });
    return this.http.get(
      `${environment.baseApiUrl}/search/movie?query=${movieName}&page=${page}`,
      {headers},
    );
  }

  getMoviesByTrand(trandBy: string) {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });
    return this.http.get(
      `${environment.baseApiUrl}/trending/movie/${trandBy}`,
      {headers},
    );
  }

  getTypetv(page: number = 1, TvType:string) {
    type TvType = 'popular' | 'now_playing' | 'top_rated' | 'upcoming';
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${environment.apiKey}`,
      'accept': 'application/json'
    });
    return this.http.get(
      `${environment.baseApiUrl}/tv/${TvType}?api_key=${environment.apiKey}&page=${page}`,
      // `${environment.apiUrl}/movie/now_playing?api_key=${environment.apiKey}&page=${page}`
      {headers},
    );
  }

  items = signal<any[]>([]);
  searchContent = ""

  // "https://api.themoviedb.org/3/trending/movie/day"
}