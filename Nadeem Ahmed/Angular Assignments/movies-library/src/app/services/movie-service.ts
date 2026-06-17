import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MovieService {


  constructor(private http: HttpClient) { }

  private getHeaders() {
    return new HttpHeaders({
      Authorization: `Bearer ${environment.api.bearerToken}`
    });
  }

  getPopularMovies(page: number) {
    return this.http.get<any>(
      `${environment.api.baseUrl}/movie/popular?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  getUpcomingMovies(page:number) {
    return this.http.get<any>(
      `${environment.api.baseUrl}/movie/upcoming?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  getTopRatedMovies(page:number) {
    return this.http.get<any>(
      `${environment.api.baseUrl}/movie/top_rated?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  getNowPlaying(page:number) {
    return this.http.get<any>(
      `${environment.api.baseUrl}/movie/now_playing?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  

}
