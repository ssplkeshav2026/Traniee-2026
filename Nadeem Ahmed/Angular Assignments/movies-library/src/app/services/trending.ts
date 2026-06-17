import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class Trending {
  constructor(private http: HttpClient) { }

  private getHeaders() {
    return new HttpHeaders({
      Authorization: `Bearer ${environment.api.bearerToken}`
    });

  }

  getTrending(type: string) {
    return this.http.get(
      `${environment.api.baseUrl}/trending/all/${type}`,
      { headers: this.getHeaders() }
    );
  }



}