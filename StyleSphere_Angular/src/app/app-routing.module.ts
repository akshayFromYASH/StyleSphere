import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserloginComponent } from './User/userlogin/userlogin.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { UserregisterComponent } from './User/userregister/userregister.component';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProductaddComponent } from './Seller/productadd/productadd.component';
import { HomeComponent } from './home/home.component';
import { ProdlistComponent } from './Seller/prodlist/prodlist.component';
import { UserdetailsComponent } from './User/userdetails/userdetails.component';
import { SellerdashboardComponent } from './Seller/sellerdashboard/sellerdashboard.component';
import { ProducteditComponent } from './Seller/productedit/productedit.component';
import { UsereditComponent } from './User/useredit/useredit.component';
import { MyproductsComponent } from './Seller/myproducts/myproducts.component';
import { ProductbuyComponent } from './Customer/productbuy/productbuy.component';
import { ProductdetailsComponent } from './Seller/productdetails/productdetails.component';
import { GotocartComponent } from './Customer/gotocart/gotocart.component';
import { AddShippingAddressComponent } from './Customer/add-shipping-address/add-shipping-address.component';
import { OrderDetailsComponent } from './Customer/order-details/order-details.component';
import { PaymentPageComponent } from './Customer/payment-page/payment-page.component';

const routes: Routes = [
  {path:'home',component:HomeComponent},
  {path:'app',component:AppComponent},
  {path:'navbar',component:NavbarComponent},
  {path:'userDetails/:id',component:UserdetailsComponent},
  {path:"userLogin",component:UserloginComponent},
  {path:"userRegister",component:UserregisterComponent},
  {path:"userEdit/:userid",component:UsereditComponent},
  {path:"productadd",component:ProductaddComponent},
  {path:"productList",component:ProdlistComponent},
  {path:"productEdit/:{prodid}",component:ProducteditComponent},
  {path:"productDetails/:{prodid}",component:ProductdetailsComponent},
  {path:"myproducts/:{userid}",component:MyproductsComponent},
  {path:"sellerDashboard",component:SellerdashboardComponent},
  {path:"buy/:prodid",component:ProductbuyComponent},
  {path:"gotocart/:userid",component:GotocartComponent},
  {path:"shippingAddress/:prodid",component:AddShippingAddressComponent},
  {path:"orderDetails/:orderid",component:OrderDetailsComponent},
  {path:"paymentPage/:prodid",component:PaymentPageComponent},
  {path:"**",component:PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
