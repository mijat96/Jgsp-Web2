import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObrisiLinijaComponent } from './obrisi-linija.component';

describe('ObrisiLinijaComponent', () => {
  let component: ObrisiLinijaComponent;
  let fixture: ComponentFixture<ObrisiLinijaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObrisiLinijaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObrisiLinijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
