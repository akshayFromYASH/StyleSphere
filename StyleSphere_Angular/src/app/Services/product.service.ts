import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../Models/Product';
import { catchError, Observable, throwError } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiUrl: string = 'http://localhost:5145/Product';
  userid: number;

  httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) };

  constructor(private http: HttpClient, private activeRoute: ActivatedRoute) { }

  AddProduct(product: Product): Observable<any> {
    console.log("product :" + product);
    return this.http.post<any>(this.apiUrl, product, this.httpOptions).pipe(catchError(this.handleError));
  }

  getAllProducts(): Observable<any> {
    return this.http.get<Product>(this.apiUrl);
  }

  getProductById(id: number): Observable<any> {
    console.log("From user.service.ts ==> " + id);
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  getProductsByUserId(userid: number): Observable<Product[]> { 
    return this.http.get<Product[]>(`${this.apiUrl}/GetProductsByUserId/${userid}`); 
  }

  UpdateProduct(id: number, product: Product): Observable<Product> {
    return this.http.put<Product>(this.apiUrl + "/" + id, product, this.httpOptions).pipe(catchError(this.handleError))
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + "/" + id);
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = "";
    errorMessage = error.status + '\n' + error.statusText + '\n' + error.error;
    alert(errorMessage);
    return throwError(errorMessage);
  }
}
