import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajStanicuComponent } from './dodaj-stanicu.component';

describe('DodajStanicuComponent', () => {
  let component: DodajStanicuComponent;
  let fixture: ComponentFixture<DodajStanicuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DodajStanicuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajStanicuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
