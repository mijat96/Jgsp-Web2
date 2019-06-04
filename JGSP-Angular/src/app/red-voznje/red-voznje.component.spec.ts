import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedVoznjeComponent } from './red-voznje.component';

describe('RedVoznjeComponent', () => {
  let component: RedVoznjeComponent;
  let fixture: ComponentFixture<RedVoznjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedVoznjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedVoznjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
