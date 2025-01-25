import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from '../Services/cart.service';
import { Cart } from '../Models/Cart';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  title = 'StyleSphere_Angular';
  role: string | null = '';
  loggedIn: boolean = false;
  userid: number;
  cartItems: Cart[] = [];

  constructor(private _cart: CartService, private router: Router) {}

  ngOnInit(): void {
    this.updateLoginStatus();

    // Listen to changes in sessionStorage and localStorage
    window.addEventListener('storage', () => {
      this.updateLoginStatus();
    });
  }

  updateLoginStatus(): void {
    this.role = sessionStorage.getItem("userrole");
    this.loggedIn = localStorage.getItem("logged") === 'true';
    this.userid = parseInt(sessionStorage.getItem('userid') || '0', 10);
    if (this.loggedIn) {
      this.fetchCartItems();
    }
  }

  fetchCartItems(): void {
    this.router.navigate(['/gotocart', this.userid])
  }

  logout(): void {
    sessionStorage.removeItem("userrole");
    sessionStorage.removeItem("loginToken");
    localStorage.removeItem("logged");
    this.updateLoginStatus();
    this.router.navigate(['userLogin']);
  }
}
