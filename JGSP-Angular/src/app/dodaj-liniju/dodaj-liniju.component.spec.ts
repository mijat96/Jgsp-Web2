import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajLinijuComponent } from './dodaj-liniju.component';

describe('DodajLinijuComponent', () => {
  let component: DodajLinijuComponent;
  let fixture: ComponentFixture<DodajLinijuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DodajLinijuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajLinijuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
