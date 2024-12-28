import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserloginComponent } from './userlogin/userlogin.component';
import { authGuard } from './auth.guard';
import { SellerDasbhoardComponent } from './seller-dasbhoard/seller-dasbhoard.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { CustomerComponent } from './customer/customer.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';

const routes: Routes = [
  {path:"userLogin",component:UserloginComponent},
  {path:"sellerDashboard",component:SellerDasbhoardComponent, canActivate:[authGuard]},   // adding guard to the component
  {path:"customerDashboard",component:CustomerComponent, canActivate:[authGuard]},
  {path:"userRegister",component:UserRegistrationComponent},
  {path:"**",component:PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
