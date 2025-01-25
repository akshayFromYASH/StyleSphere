import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent {
  user: User;
  userid: number;
  constructor(private _user: UserService, private activeroute: ActivatedRoute,private router:Router) { }

  ngOnInit() {
    this.userid = parseInt(sessionStorage.getItem('userid') || '0', 10);   // if session value is null assigns it to 0, and 10 is to use it as base for the conversion

    // let Id=this.activeroute.snapshot.params['id'];
    console.log("From UserDetails Component ==> " + this.userid);
    this._user.getUserById(this.userid).subscribe(data => {
      this.user = data;
      this.userid = data.userId;
      console.log(data.userId);
      localStorage.setItem('userid', data.userId.toString());
      console.log(data);
    });
  }

  navigateToEditUser(userid: number) { 
    this.router.navigate([`/userDetails/${userid}/userEdit`]); }
}
