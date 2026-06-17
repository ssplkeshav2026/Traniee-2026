import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardBar } from './card-bar';

describe('CardBar', () => {
  let component: CardBar;
  let fixture: ComponentFixture<CardBar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardBar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardBar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
