import { Component, OnInit } from '@angular/core';
import { HttpClient , HttpParams,HttpHeaders } from '@angular/common/http';
import { DatePipe } from '@angular/common'






@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  CarsArray:any=[];
  CarsArrayById:any =[];
CarsCategory:any=[];
Price:number;
  n1:number;
  n2:number;
  CarsById:any;
  tt:any=[];
  searchByModel:any;
  mes:any; 
  id:string;
  manufacture:string;
  Available:string;
  PricePerDay:number;
  lateCostPerDay:number;
  model:any;
  modelArray:any=[];
  userId:number;
  carId:any;  
  sDate:any;
  eDate:any;  
ordersArray:any=[];
carsArray1:any=[];
carsArray2:any=[];


 

  constructor(public h:HttpClient,public datepipe: DatePipe){
    h.get("http://localhost:49924/api/cars/getcars").subscribe(data=>{
      this.CarsArray = data;
      this.arraySplit(this.CarsArray);
      this.arraySplit2(this.CarsArray);
    });
    h.get("http://localhost:49924/api/cars/GetOrders").subscribe(t=>this.ordersArray=t);
   
  }
// array split for better display
  arraySplit(CarsArray:any){
for (let i = 0; i < CarsArray.length; i++) {
  if (i<5) {
    this.carsArray1[i]=CarsArray[i];
  }
}
  }
  // array split for better display
  arraySplit2(CarsArray:any){
    var j=0;  
    for (let i = 5; i < CarsArray.length; i++) {
       this.carsArray2[j]=CarsArray[i];
       j++;
        }}
// get all cars from api
  getAllCars(){
    this.h.get("http://localhost:49924/api/cars/getcars").subscribe(x=> this.CarsArray = x);
  }
// get total price for a car rental
  getPrice(carPrice:number,rentalDays:number){
    this.Price=carPrice*rentalDays
  }
  // get car by iserting a model from web api
  SearchByModel(model:string){
    for (let i = 0; i < this.CarsArray.length; i++) {
      if (this.CarsArray[i].model == model) {
        this.model=this.CarsArray[i].model;
        this.manufacture = this.CarsArray[i].manufacture;
        this.id =this.CarsArray[i].id;
        this.PricePerDay =parseInt(this.CarsArray[i].pricePerDay);
        this.lateCostPerDay =parseInt(this.CarsArray[i].lateCost);
        this.Available = this.CarsArray[i].available;
        this.carId=this.CarsArray[i].id;
      }
      
      
    }
  };
  // make a new order 
  PlaceOrder(carId:string,sDate:any,eDate:any
  ){
    var token = localStorage.getItem("token");
    var id =parseInt( localStorage.getItem("userID"));
    var header = new HttpHeaders();
    header = header.append("Authorization", "Bearer " + token);
    

    if ((this.sDate == null || this.eDate == null)||(this.sDate > this.eDate)) {
      alert("please insert valid dates");
    }
    else if(this.cheackDates(carId,sDate,eDate) == false ){
      alert("Dates not available");
    }
    else {

    let startDate =this.datepipe.transform(sDate, 'yyyy, MM, dd');
   
    let endDate =this.datepipe.transform(eDate, 'yyyy, MM, dd');
  
   var url = "http://localhost:49924/api/cars/AddNewOrder";
let order =
 {
   "UserId": id,
"pickUpDate": startDate,
"dropOffDate": endDate,
"realDropOffDate": endDate,
"carId": carId
}
this.h.post(url,order,{"headers": header}).subscribe(t=>this.mes=t);
alert("Your order has been set!");

    };
    
 }
 ;
// varify available dates
 cheackDates(cariD:string, sDate:string,eDate:string):boolean{
   for (let i = 0; i < this.ordersArray.length; i++) {
     if(this.ordersArray[i].id == cariD){

       if (sDate < this.ordersArray[i].pickUpDate && eDate < this.ordersArray[i].pickUpDate) {
         return true;
       }else if 
       (sDate > this.ordersArray[i].dropOffDate ) {
        return true;
       }else{
         return false;
       };

     }
     
   }
 }
 

  ngOnInit(): void {
  }

}
