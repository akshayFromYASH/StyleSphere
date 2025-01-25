import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-productedit',
  templateUrl: './productedit.component.html',
  styleUrls: ['./productedit.component.css']
})
export class ProducteditComponent implements OnInit {
  product: Product;
  prodId: number;

  constructor(private service: ProductService, private activeRoute: ActivatedRoute, private route: Router) { }

  ngOnInit() {
    this.prodId = parseInt(localStorage.getItem('prodId') || '0',10);  
    console.log("Product ID = " + this.prodId);
    this.service.getProductById(this.prodId).subscribe(data => {
      this.product = data;
      console.log(this.product);
    })
  }

  onSubmit() {
    this.service.UpdateProduct(this.prodId, this.product).subscribe(data => {
      alert("Product data updated!");
      this.route.navigate(['/productList']);
    },
      error => alert(error.errorMessage)
    );
  }
}
