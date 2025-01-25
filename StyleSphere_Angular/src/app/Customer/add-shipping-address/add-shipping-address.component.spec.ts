import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShippingAddressComponent } from './add-shipping-address.component';

describe('AddShippingAddressComponent', () => {
  let component: AddShippingAddressComponent;
  let fixture: ComponentFixture<AddShippingAddressComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddShippingAddressComponent]
    });
    fixture = TestBed.createComponent(AddShippingAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
