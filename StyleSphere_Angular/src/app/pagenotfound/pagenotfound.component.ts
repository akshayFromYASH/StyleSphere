import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pagenotfound',
  templateUrl: './pagenotfound.component.html',
  styleUrls: ['./pagenotfound.component.css']
})
export class PagenotfoundComponent {
  constructor(private router: Router) { } 
  goHome() { 
    this.router.navigate(['/']); 
  } 
  contactSupport() { 
    window.location.href = 'mailto:support@example.com'; 
  }
}
