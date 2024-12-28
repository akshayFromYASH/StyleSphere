import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Models/User';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl : "http://localhost:5145/User";
  constructor(private http:HttpClient) { }

  UserRegistration(user:User):Observable<User>{
    console.log(user);
    return this.http.post<User>(this.apiUrl,user);
  }

  handleError(error:HttpErrorResponse){
    let errorMessage="";
    errorMessage=error.status +'\n'+error.statusText+'\n'+error.error;
    alert(errorMessage);
    return throwError(errorMessage);
  }
}
