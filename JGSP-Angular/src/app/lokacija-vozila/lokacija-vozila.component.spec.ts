import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LokacijaVozilaComponent } from './lokacija-vozila.component';

describe('LokacijaVozilaComponent', () => {
  let component: LokacijaVozilaComponent;
  let fixture: ComponentFixture<LokacijaVozilaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LokacijaVozilaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LokacijaVozilaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
