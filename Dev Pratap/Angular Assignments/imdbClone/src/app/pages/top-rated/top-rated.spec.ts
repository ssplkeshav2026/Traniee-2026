import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRated } from './top-rated';

describe('TopRated', () => {
  let component: TopRated;
  let fixture: ComponentFixture<TopRated>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopRated]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopRated);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
