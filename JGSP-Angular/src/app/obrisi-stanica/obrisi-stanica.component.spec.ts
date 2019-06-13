import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObrisiStanicaComponent } from './obrisi-stanica.component';

describe('ObrisiStanicaComponent', () => {
  let component: ObrisiStanicaComponent;
  let fixture: ComponentFixture<ObrisiStanicaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObrisiStanicaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObrisiStanicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
