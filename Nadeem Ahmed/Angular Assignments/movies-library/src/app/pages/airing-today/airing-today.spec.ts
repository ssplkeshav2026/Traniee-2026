import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AiringToday } from './airing-today';

describe('AiringToday', () => {
  let component: AiringToday;
  let fixture: ComponentFixture<AiringToday>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AiringToday],
    }).compileComponents();

    fixture = TestBed.createComponent(AiringToday);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
