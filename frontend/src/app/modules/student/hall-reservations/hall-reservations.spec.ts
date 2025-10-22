import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HallReservations } from './hall-reservations';

describe('HallReservations', () => {
  let component: HallReservations;
  let fixture: ComponentFixture<HallReservations>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HallReservations]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HallReservations);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
