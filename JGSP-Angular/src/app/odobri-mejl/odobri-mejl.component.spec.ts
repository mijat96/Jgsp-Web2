import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OdobriMejlComponent } from './odobri-mejl.component';

describe('OdobriMejlComponent', () => {
  let component: OdobriMejlComponent;
  let fixture: ComponentFixture<OdobriMejlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OdobriMejlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OdobriMejlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
