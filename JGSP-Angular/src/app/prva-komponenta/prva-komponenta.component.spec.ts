import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrvaKomponentaComponent } from './prva-komponenta.component';

describe('PrvaKomponentaComponent', () => {
  let component: PrvaKomponentaComponent;
  let fixture: ComponentFixture<PrvaKomponentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrvaKomponentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrvaKomponentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
