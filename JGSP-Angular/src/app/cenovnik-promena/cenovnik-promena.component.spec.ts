import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenovnikPromenaComponent } from './cenovnik-promena.component';

describe('CenovnikPromenaComponent', () => {
  let component: CenovnikPromenaComponent;
  let fixture: ComponentFixture<CenovnikPromenaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenovnikPromenaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenovnikPromenaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
