import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpComing } from './up-coming';

describe('UpComing', () => {
  let component: UpComing;
  let fixture: ComponentFixture<UpComing>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpComing]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpComing);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
