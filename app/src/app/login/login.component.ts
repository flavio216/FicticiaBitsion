
import { Component , OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiAuthService } from '../services/apiauth.service';



@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit{
    public email: string = "";
    public password: string = "";
    constructor(public apiauth: ApiAuthService, private router: Router) 
    {
                
    }
    ngOnInit() {
         

}
login(){
  
}
/*login(){ 

this.apiauth.login(this.email, this.password).subscribe(response=>{
    if(response.success === 1){
      this.router.navigate(['/'])
    }
    });
  }*/
}