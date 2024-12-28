import { Component } from '@angular/core';
import { User } from '../Models/User';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlogin',  // The HTML tag that represents this component.
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent {
  currentuser : User = {    // Initializes an empty User object to hold form data.
    userId: 0,
    userName: '',
    email: '',
    password:  '',
    phoneNumber: '',
    status: '',
    userRole: ''
  }
  constructor(private _service: AuthService, private router:Router){}     // Injects the authentication and router servie

  isLoggedin:string ='true';

  Role:string = ''
  onSubmit(form:any){
    let loginuser = form.value;                               // Extracts the form data.
    this._service.Login(loginuser).subscribe((res: any) =>{
      if(res.status == 200){

        // localstorage ==> to hold unencrypted data
        localStorage.setItem('logged',this.isLoggedin);       // Stores the login status in local storage.
        // sessionStorage ==> to hold encrypted data
        sessionStorage.setItem('loginToken',res.body.token)   // Stores the token in session storage

        // printing token on console
        console.log("Token is .......");
        console.log(res.body.token);

        sessionStorage.setItem('userrole',res.body.userRole)
        
        this.Role = sessionStorage.getItem("userrole") || ''
        console.log(this.Role);
        if(this.Role === 'seller'){
          alert("login Success");
          this.router.navigate(['sellerDashboard'])
        }
        else
         this.router.navigate(['customerDashboard'])
      }
      }, (err:any) => {
        alert("There was a problem logging " + err.message);
      
    });
  }
}
