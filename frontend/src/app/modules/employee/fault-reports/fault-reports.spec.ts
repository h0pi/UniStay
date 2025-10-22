import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FaultReports } from './fault-reports';

describe('FaultReports', () => {
  let component: FaultReports;
  let fixture: ComponentFixture<FaultReports>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FaultReports]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FaultReports);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
