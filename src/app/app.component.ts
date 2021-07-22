import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'CarRental';
  username:string;
  password:string;
  user:any;
  token:string;
  arr:any =[];
  userConnected:boolean=true;
  logoutBool:boolean=false;
  
 
  adminRole:boolean = false
  employeeRole:boolean = false
  
  
  constructor(public h:HttpClient) {
    var userRole = localStorage.getItem("role");
    this.roleCheker(userRole);
    
   }
   // checks the user role
  roleCheker(userRole:string){
  
  if (userRole == "admin") {
    this.adminRole = true;
    
  }else if(userRole == "employee"){
    this.employeeRole = true;
    this.adminRole = false;
  }else{

    this.adminRole = false;
    this.employeeRole = false;
  }
  
  }
// logout function
logout(){
  localStorage.removeItem("role")
  localStorage.removeItem("userID")
  localStorage.removeItem("token")
  this.userConnected=true;
  this.logoutBool = false;
  this.adminRole = false;
  this.employeeRole = false;
}

  
// login function
  Login(username:string, password:string){
    let userLogin = {
      "UserName" :username,
        "Password":password,
    }
    this.h.post("http://localhost:49924/api/Authorization/Login",userLogin).subscribe(data=>{
      this.user = data;
      
      localStorage.setItem('token',this.user.accessToken);
      localStorage.setItem('role',this.user.role);
      localStorage.setItem('userID',this.user.id);

      this.roleCheker(this.user.role);
      this.userConnected=false;
      this.logoutBool=true;
      
      console.log(this.logoutBool);

    });
    
  }
  

  
  
}
