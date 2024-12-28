import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellerDasbhoardComponent } from './seller-dasbhoard.component';

describe('SellerDasbhoardComponent', () => {
  let component: SellerDasbhoardComponent;
  let fixture: ComponentFixture<SellerDasbhoardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SellerDasbhoardComponent]
    });
    fixture = TestBed.createComponent(SellerDasbhoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
