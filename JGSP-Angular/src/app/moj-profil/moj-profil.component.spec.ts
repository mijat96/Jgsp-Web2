import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MojProfilComponent } from './moj-profil.component';

describe('MojProfilComponent', () => {
  let component: MojProfilComponent;
  let fixture: ComponentFixture<MojProfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MojProfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MojProfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
