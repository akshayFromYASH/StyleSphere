import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/Product';

@Component({
  selector: 'app-myproducts',
  templateUrl: './myproducts.component.html',
  styleUrls: ['./myproducts.component.css']
})
export class MyproductsComponent implements OnInit {
  products: Product[] = [];
  userid: number;

  constructor(private activeRoute: ActivatedRoute, private service: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.userid = parseInt(sessionStorage.getItem('userid') || '0', 10);
    console.log("UserId from session storage: " + this.userid);
    this.loadProductsByUserId();
  }

  loadProductsByUserId(): void {
    this.service.getProductsByUserId(this.userid).subscribe(
      data => {
        this.products = data;
        console.log("Products loaded: ", this.products);
      },
      error => {
        console.error('Error fetching products', error);
      }
    );
  }
}
