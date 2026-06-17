import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcomingMovies } from './upcoming-movies';

describe('UpcomingMovies', () => {
  let component: UpcomingMovies;
  let fixture: ComponentFixture<UpcomingMovies>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpcomingMovies],
    }).compileComponents();

    fixture = TestBed.createComponent(UpcomingMovies);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
