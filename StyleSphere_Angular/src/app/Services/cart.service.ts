import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cart } from '../Models/Cart';
import { catchError, Observable, throwError } from 'rxjs';
import { Product } from '../Models/Product';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  apiUrl: string = 'http://localhost:5145/Cart';
  userid: number;

  httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) };

  constructor(private http: HttpClient, private activeRoute: ActivatedRoute) { }

  AddtoWishlist(wishlistItem: Cart): Observable<any> {
    console.log("cart :" + wishlistItem);
    return this.http.post<any>(this.apiUrl, wishlistItem, this.httpOptions).pipe(catchError(this.handleError));
  }

  ProductInWishList(prodid: number):boolean{
    console.log("prodid",prodid);
    if(this.http.get(this.apiUrl)  != null){
      return true
    }
    else{
      return false
    }  
  }
  updateWishlist(prodid:number,wishlistItem: Cart){
    console.log("prodid: ",prodid);
    return this.http.put(this.apiUrl,wishlistItem);
  }
  RemoveFromWishlist(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + "/" + id);
  }

  getCartByUserId(userId: number): Observable<Cart[]> { 
    return this.http.get<Cart[]>(`${this.apiUrl}?userId=${userId}`); 
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = "";
    errorMessage = error.status + '\n' + error.statusText + '\n' + error.error;
    alert(errorMessage);
    return throwError(errorMessage);
  }

}
