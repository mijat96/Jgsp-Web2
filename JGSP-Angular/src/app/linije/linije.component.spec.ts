import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinijeComponent } from './linije.component';

describe('LinijeComponent', () => {
  let component: LinijeComponent;
  let fixture: ComponentFixture<LinijeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinijeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
