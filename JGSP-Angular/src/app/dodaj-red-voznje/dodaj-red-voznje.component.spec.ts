import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajRedVoznjeComponent } from './dodaj-red-voznje.component';

describe('DodajRedVoznjeComponent', () => {
  let component: DodajRedVoznjeComponent;
  let fixture: ComponentFixture<DodajRedVoznjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DodajRedVoznjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajRedVoznjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
