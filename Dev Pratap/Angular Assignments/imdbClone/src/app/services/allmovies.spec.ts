import { TestBed } from '@angular/core/testing';

import { Allmovies } from './allmovies';

describe('Allmovies', () => {
  let service: Allmovies;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Allmovies);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
