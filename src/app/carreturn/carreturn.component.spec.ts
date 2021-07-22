import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarreturnComponent } from './carreturn.component';

describe('CarreturnComponent', () => {
  let component: CarreturnComponent;
  let fixture: ComponentFixture<CarreturnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarreturnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarreturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
