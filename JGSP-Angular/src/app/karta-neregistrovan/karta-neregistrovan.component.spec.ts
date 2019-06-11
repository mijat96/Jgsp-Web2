import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KartaNeregistrovanComponent } from './karta-neregistrovan.component';

describe('KartaNeregistrovanComponent', () => {
  let component: KartaNeregistrovanComponent;
  let fixture: ComponentFixture<KartaNeregistrovanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KartaNeregistrovanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KartaNeregistrovanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
