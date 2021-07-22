import { Component, OnInit } from '@angular/core';
import { HttpClient,HttpHeaders} from '@angular/common/http';
import { observable } from 'rxjs';

@Component({
  selector: 'app-carreturn',
  templateUrl: './carreturn.component.html',
  styleUrls: ['./carreturn.component.css']
})
export class CarreturnComponent implements OnInit {
id:any;
Date:any;
available:any;
carId:any
OrdersArray:any=[];

CarsArray1:any=[];
h:HttpClient; 

 constructor(htto:HttpClient) {
   this.h=htto
 }

   
// return car from  the client

returnCar (available1:string, id:number , Date:string , carId:number){
  var token = localStorage.getItem("token");
  var header = new HttpHeaders();
  header = header.append("Authorization", "Bearer " + token);

  var bodyReturn = {
    "RealDropOffDate": Date, 
    "userId": parseInt(id.toString()),
    "carId": parseInt(carId.toString())
  }
  
var bodyAvailable = {"Available": available1}

    
      this.h.put<any>("http://localhost:49924/api/cars/ReturnOrder/"+id,bodyReturn,{"headers": header}).subscribe(x=> this.CarsArray1[0] = x);
      this.h.put<any>("http://localhost:49924/api/cars/UpdateCarAvailable/"+carId,bodyAvailable,{"headers": header}).subscribe(); 
}
getAllOrders(){
  var token = localStorage.getItem("token");
  const httpHeaders = new HttpHeaders({
'content-type': 'application/json',
'Authorization': token
  });    
  this.h.get("http://localhost:49924/api/cars/GetOrders").subscribe(t=>this.OrdersArray=t);
}
 

  ngOnInit(): void {
  }

}
