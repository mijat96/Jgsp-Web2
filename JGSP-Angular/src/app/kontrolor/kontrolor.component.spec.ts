import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KontrolorComponent } from './kontrolor.component';

describe('KontrolorComponent', () => {
  let component: KontrolorComponent;
  let fixture: ComponentFixture<KontrolorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KontrolorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KontrolorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
