import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeTable } from './home-table';

describe('HomeTable', () => {
  let component: HomeTable;
  let fixture: ComponentFixture<HomeTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
