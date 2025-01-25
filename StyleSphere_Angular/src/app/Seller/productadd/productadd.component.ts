import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-productadd',
  templateUrl: './productadd.component.html',
  styleUrls: ['./productadd.component.css']
})
export class ProductaddComponent implements OnInit {
  productForm: FormGroup;
  product: Product;

  constructor(private fb: FormBuilder, private service: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.productForm = this.fb.group({
      prodId: [0],
      prodName: [''],
      description: [''],
      image: [''],
      availaibility: [''],
      categoryId: [''],
      userId: [''],
      price: [0],
      stock_Quantity: [0]
    });
  }

  onSubmit(form: any) {
    this.productForm = form;
    console.log('Form Values:', this.productForm.value);
    if (this.productForm.valid) {
      const formValues = this.productForm.value;
      this.product = {
        prodId: formValues.prodId,
        prodName: formValues.prodName,
        description: formValues.description,
        image: formValues.image,
        availaibility: formValues.availaibility,
        categoryId: formValues.categoryId,
        userId: formValues.userId,
        price: formValues.price,
        stock_Quantity: formValues.stock_Quantity
      };

      console.log('Product to be added:', this.product);

      this.service.AddProduct(this.product).subscribe(
        response => {
          console.log('Product Added successfully!', response);
          this.router.navigate(['productList']);
        },
        error => {
          console.error('Error Adding Product', error);
        }
      );
    }
  }
}

