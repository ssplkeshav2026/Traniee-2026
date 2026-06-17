import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRatedTvshows } from './top-rated-tvshows';

describe('TopRatedTvshows', () => {
  let component: TopRatedTvshows;
  let fixture: ComponentFixture<TopRatedTvshows>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopRatedTvshows],
    }).compileComponents();

    fixture = TestBed.createComponent(TopRatedTvshows);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
