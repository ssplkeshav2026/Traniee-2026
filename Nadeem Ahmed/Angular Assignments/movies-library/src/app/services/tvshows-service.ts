import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TvshowsService {


  constructor(private http: HttpClient) { }

  private getHeaders() {
    return new HttpHeaders({
      Authorization: `Bearer ${environment.api.bearerToken}`
    });
  }

  getPopularTVShows(page:number) {
    return this.http.get(
      `${environment.api.baseUrl}/tv/popular?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  getTopRatedTVShows(page:number) {
    return this.http.get(
      `${environment.api.baseUrl}/tv/top_rated?page=${page}`,
      { headers: this.getHeaders() }
    );
  }

  getOnTV(page:number) {
    return this.http.get(
      `${environment.api.baseUrl}/tv/on_the_air?page=${page}`,
      { headers: this.getHeaders() }
    );
  }
  getAiringToday(page:number) {
    return this.http.get(
      `${environment.api.baseUrl}/tv/airing_today?page=${page}`,
      { headers: this.getHeaders() }
    );
  }
}
