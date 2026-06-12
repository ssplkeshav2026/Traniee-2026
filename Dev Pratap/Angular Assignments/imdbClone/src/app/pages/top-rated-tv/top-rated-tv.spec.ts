import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRatedTv } from './top-rated-tv';

describe('TopRatedTv', () => {
  let component: TopRatedTv;
  let fixture: ComponentFixture<TopRatedTv>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopRatedTv]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopRatedTv);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
