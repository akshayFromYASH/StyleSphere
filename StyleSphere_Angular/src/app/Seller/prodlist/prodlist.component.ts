import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Cart } from 'src/app/Models/Cart';
import { Product } from 'src/app/Models/Product';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-prodlist',
  templateUrl: './prodlist.component.html',
  styleUrls: ['./prodlist.component.css']
})
export class ProdlistComponent {
  products: Product[] = [];
  userid: number;
  role: string;
  product: Product;
  prodId: number;
  wishlistItem: Cart;
  cart: Cart
  student: string[] = ["akshay", "ajay", "adfadf"]
  constructor(private _product: ProductService, private _cart: CartService, private router: Router) { }
  ngOnInit() {
    this.userid = parseInt(localStorage.getItem('userid') || '0', 10);
    this.role = localStorage.getItem('role') || 'customer';
    this._product.getAllProducts().subscribe(data => {
      this.products = data;
      console.log(this.products);
    })
  }
  showDetails(prodid: number): void {
    this.prodId = prodid;
    console.log("prodId" + this.prodId);
    this.router.navigate(['/productDetails', this.prodId]);

  }

  addToWishlist(prodid: number): void {
    this.prodId = prodid;
    console.log("prodid" + prodid);
    localStorage.setItem("prodid", this.prodId.toString());
    console.log("prodId" + this.prodId);

    
    this.wishlistItem = {
      cartId: 0,
      userId: this.userid,
      prodId: prodid,
      quantity: 1, // Default quantity 
      cart_Amount: 0 // Set to 0 as it's a wishlist
    };
    
    if(this._cart.ProductInWishList(this.prodId)){
      this.wishlistItem.quantity = this.cart.quantity + 1;
      this._cart.updateWishlist(prodid,this.wishlistItem).subscribe(data => {
        alert('Product added to wishlist');
      },
      error => {
        console.error('Error updating  product to wishlist:', error);
        alert('Failed to update product to wishlist. Please try again.');
      });
    }
    else{
      this._cart.AddtoWishlist(this.wishlistItem).subscribe(response => {
        console.log('Product added to wishlist:', response);
        alert('Product added to wishlist!');
        this.router.navigate(['/gotocart',this.userid])
      },
        error => {
          console.error('Error adding product to wishlist:', error);
          alert('Failed to add product to wishlist. Please try again.');
        });
    }

    
  }

  buy(prodid: number): void {
    this.prodId = prodid;
    alert("Proceed to buy");
    console.log("prodid" + prodid);
    localStorage.setItem("prodid", this.prodId.toString());
    console.log("prodId" + this.prodId);
    // this.router.navigate(['/buy/{prodid}']);
    this.router.navigate(['/buy', this.prodId]);
  }
}
