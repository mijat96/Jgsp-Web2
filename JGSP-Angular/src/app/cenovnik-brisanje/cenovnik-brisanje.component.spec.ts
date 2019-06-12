import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenovnikBrisanjeComponent } from './cenovnik-brisanje.component';

describe('CenovnikBrisanjeComponent', () => {
  let component: CenovnikBrisanjeComponent;
  let fixture: ComponentFixture<CenovnikBrisanjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenovnikBrisanjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenovnikBrisanjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
