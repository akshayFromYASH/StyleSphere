import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/Models/Cart';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-gotocart',
  templateUrl: './gotocart.component.html',
  styleUrls: ['./gotocart.component.css']
})
export class GotocartComponent {
  cartItems: Cart[] = []; 
  userId: number; 

  constructor(private _cart: CartService, private router:Router, private _product:ProductService) { } 
  ngOnInit(): void { 
    this.userId = parseInt(localStorage.getItem('userid') || '0', 10); 
    this.fetchCartItems(); 
  } 
  

  fetchCartItems(): void { 
    this._cart.getCartByUserId(this.userId).subscribe(data => { 
      this.cartItems = data; 
      console.log('Cart items:', this.cartItems); 
    }, 
    error => { 
      console.error('Error fetching cart items:', error); 
    }); 
  }

  removeFromCart(cartId: number): void { 
    this._cart.RemoveFromWishlist(cartId).subscribe( response => { 
      console.log(`Removed item with cartId ${cartId} from cart`); 
      this.fetchCartItems(); // Refresh the cart items 
      }, error => { 
        console.error('Error removing item from cart:', error); 
        alert('Failed to remove item from cart. Please try again.'); 
      }); 
    } 
    
    buy(prodid: number): void { 
      console.log(`Buying product with prodId ${prodid}`); 
      this.router.navigate(['/buy', prodid]); 
    }
}
