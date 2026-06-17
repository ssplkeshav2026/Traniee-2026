import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRatedMovies } from './top-rated-movies';

describe('TopRatedMovies', () => {
  let component: TopRatedMovies;
  let fixture: ComponentFixture<TopRatedMovies>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopRatedMovies],
    }).compileComponents();

    fixture = TestBed.createComponent(TopRatedMovies);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
