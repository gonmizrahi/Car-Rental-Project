import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { CarsComponent } from './cars/cars.component';
import { PriceCalcsComponent } from './price-calcs/price-calcs.component';
import { RegisterComponent } from './register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { CarreturnComponent } from './carreturn/carreturn.component';


import { DatePipe } from '@angular/common';
import { ManagerComponent } from './manager/manager.component'



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CarsComponent,
    PriceCalcsComponent,
    RegisterComponent,
    OrdersComponent,
    CarreturnComponent,
    ManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,FormsModule, 
    
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
