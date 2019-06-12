import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenovnikDodajComponent } from './cenovnik-dodaj.component';

describe('CenovnikDodajComponent', () => {
  let component: CenovnikDodajComponent;
  let fixture: ComponentFixture<CenovnikDodajComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenovnikDodajComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenovnikDodajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
