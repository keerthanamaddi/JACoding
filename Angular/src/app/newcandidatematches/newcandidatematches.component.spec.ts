import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewcandidatematchesComponent } from './newcandidatematches.component';

describe('NewcandidatematchesComponent', () => {
  let component: NewcandidatematchesComponent;
  let fixture: ComponentFixture<NewcandidatematchesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewcandidatematchesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewcandidatematchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
