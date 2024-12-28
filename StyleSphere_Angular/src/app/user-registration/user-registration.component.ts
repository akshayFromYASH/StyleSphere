import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../Models/User';
import { UserService } from '../Services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {

  registrationForm: FormGroup;

  constructor(private form: FormBuilder, private _service: UserService, private route: Router) {}

  ngOnInit(): void {
    this.registrationForm = this.form.group({
      userName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
      status: ['active'],
      userRole: ['', [Validators.required]]
    });
  }

  onSubmit(): void {
    console.log(this.registrationForm.value);
    if (this.registrationForm.valid) {
      const user: User = this.registrationForm.value;  // Correct assignment
      this._service.UserRegistration(user).subscribe(
        response => {
          alert('User Registered Successfully');
          this.route.navigate(['userLogin']);
        },
        error => {
          alert('User Registration Failed');
          console.error('Error:', error);
        }
      );
    } else {
      alert('Invalid user Information');
    }
  }
}
