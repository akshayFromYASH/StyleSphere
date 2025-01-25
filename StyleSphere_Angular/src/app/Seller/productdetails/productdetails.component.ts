import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.css']
})
export class ProductdetailsComponent {
product:Product;
prodId:number;
role: string;
constructor(private _product:ProductService, private router:Router) {}
ngOnInit(){
  this.role = localStorage.getItem('role') || 'customer';
  this._product.getProductById(this.prodId).subscribe(data => {
    this.product = data;
    console.log(this.product);
  })
}

buy(prodid:number):void{
  this.prodId = prodid;
  alert("Proceed to buy");    
  console.log("prodid"+prodid);
  console.log("prodId"+this.prodId);
  // this.router.navigate(['/buy/{prodid}']);
  this.router.navigate(['/buy',this.prodId]);
}
}
