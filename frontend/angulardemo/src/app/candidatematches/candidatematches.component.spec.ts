import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatematchesComponent } from './candidatematches.component';

describe('CandidatematchesComponent', () => {
  let component: CandidatematchesComponent;
  let fixture: ComponentFixture<CandidatematchesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandidatematchesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidatematchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
