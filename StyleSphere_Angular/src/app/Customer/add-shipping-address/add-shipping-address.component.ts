import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Shipping_Details } from 'src/app/Models/Shpping_Details';
import { ShippingService } from 'src/app/Services/shipping.service';

@Component({
  selector: 'app-add-shipping-address',
  templateUrl: './add-shipping-address.component.html',
  styleUrls: ['./add-shipping-address.component.css']
})
export class AddShippingAddressComponent implements OnInit {
  shippingDetails: Shipping_Details = new Shipping_Details();
  orderid: number;

  constructor(private _shipping: ShippingService, private router: Router, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.orderid = parseInt(this.activatedRoute.snapshot.paramMap.get('orderid') || '0', 10);
    this.shippingDetails.orderId = this.orderid;
    this.shippingDetails.userId = parseInt(sessionStorage.getItem('userid')?.toString() || '0', 10);
  }

  submitShippingDetails(): void {
    this._shipping.addShippingDetails(this.shippingDetails).subscribe(
      response => {
        console.log('Shipping details added successfully:', response);
        alert('Shipping details added successfully!');
        this.router.navigate(['/orderDetails',this.orderid]);
      },
      error => {
        console.error('Error adding shipping details:', error);
        alert('Failed to add shipping details. Please try again.');
      }
    );
  }
}
