import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Payment } from 'src/app/Models/Payment';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-payment-page',
  templateUrl: './payment-page.component.html',
  styleUrls: ['./payment-page.component.css']
})
export class PaymentPageComponent implements OnInit {
  payment: Payment = new Payment();
  productId: number;

  constructor(
    private _payment: PaymentService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    // this.productId = this.route.snapshot.paramMap.get('prodid');
    this.payment.prodId = this.productId;
    this.payment.orderDate = new Date().toISOString().split('T')[0];

    
  }

  makePayment() {
    this._payment.makePayment(this.payment).subscribe(
      response => {
        console.log('Payment successful', response);
        alert('Payment successful!');
        // this.router.navigate(['/orderDetails'],this.productId);
      },
      error => {
        console.error('Payment error', error);
        alert('Payment failed. Please try again.');
      }
    );
  }
}
