import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularTvshows } from './popular-tvshows';

describe('PopularTvshows', () => {
  let component: PopularTvshows;
  let fixture: ComponentFixture<PopularTvshows>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PopularTvshows],
    }).compileComponents();

    fixture = TestBed.createComponent(PopularTvshows);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
