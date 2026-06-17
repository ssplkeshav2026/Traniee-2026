import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnTv } from './on-tv';

describe('OnTv', () => {
  let component: OnTv;
  let fixture: ComponentFixture<OnTv>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OnTv],
    }).compileComponents();

    fixture = TestBed.createComponent(OnTv);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
