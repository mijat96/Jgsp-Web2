import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpojiStanicaLinijaComponent } from './spoji-stanica-linija.component';

describe('SpojiStanicaLinijaComponent', () => {
  let component: SpojiStanicaLinijaComponent;
  let fixture: ComponentFixture<SpojiStanicaLinijaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpojiStanicaLinijaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpojiStanicaLinijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
