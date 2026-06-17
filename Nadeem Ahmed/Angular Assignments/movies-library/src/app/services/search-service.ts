import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SearchService {

  private _query = signal<string>('');

  query = this._query.asReadonly();

  setQuery(value: string) {
    this._query.set(value);
  }

  clear() {
    this._query.set('');
  }
}
