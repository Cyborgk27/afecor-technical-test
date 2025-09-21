import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormOrder } from './form-order';

describe('FormOrder', () => {
  let component: FormOrder;
  let fixture: ComponentFixture<FormOrder>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormOrder]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormOrder);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
