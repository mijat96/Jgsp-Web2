import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObrisiRedVoznjeComponent } from './obrisi-red-voznje.component';

describe('ObrisiRedVoznjeComponent', () => {
  let component: ObrisiRedVoznjeComponent;
  let fixture: ComponentFixture<ObrisiRedVoznjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObrisiRedVoznjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObrisiRedVoznjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
