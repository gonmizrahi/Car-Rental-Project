import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarsComponent } from './cars/cars.component';
import { PriceCalcsComponent } from './price-calcs/price-calcs.component';
import { RegisterComponent } from './register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { CarreturnComponent } from './carreturn/carreturn.component';
import { ManagerComponent } from './manager/manager.component';

const routes: Routes = [
  { path: 'home', component:HomeComponent ,pathMatch: 'full'},
  { path: 'cars', component: CarsComponent },
  { path: 'return', component: CarreturnComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'pricecalc', component: PriceCalcsComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'manager', component: ManagerComponent },
  { path: '**', component: HomeComponent },
  { path: '**', component: HomeComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
