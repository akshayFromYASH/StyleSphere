import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserloginComponent } from './userlogin/userlogin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { SellerDasbhoardComponent } from './seller-dasbhoard/seller-dasbhoard.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { AuthInterceptor } from './auth.interceptor';
import { CustomerComponent } from './customer/customer.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { XsrfInterceptor } from './xsrf.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    UserloginComponent,
    SellerDasbhoardComponent,
    PagenotfoundComponent,
    CustomerComponent,
    UserRegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],

  providers: [
    // Interceptor Registration 
    { 
      provide:HTTP_INTERCEPTORS,    // interceptor is provided using the HTTP_INTERCEPTORS injection token.
      useClass : AuthInterceptor,
      multi: true                   // allows multiple interceptors to be registered.
      },
      { 
        provide:HTTP_INTERCEPTORS,    // interceptor is provided using the HTTP_INTERCEPTORS injection token.
        useClass : XsrfInterceptor,
        multi: true                   // allows multiple interceptors to be registered.
        },
      
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
