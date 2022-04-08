import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Response } from "../models/response";
import { User } from "../models/user";
import { map } from "rxjs/operators";


const httpOptions = {
    headers: new HttpHeaders({
        'Contend-Type': 'application/json'
    })
};
@Injectable({
    providedIn: "root"
})

export class ApiAuthService {
  url : string = "https://localhost:44388/api/User/login";

  /*private userSubject: BehaviorSubject<User>; 

  public get userData(): User{
    return this.userSubject.value;
  }

  constructor( private _http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
  }
  
  login(email: string, password: string): Observable<Response> {
    console.log(email);
    return this._http.post<Response>(this.url, { email, password }, httpOptions).pipe(
      map(res => {
        if(res.success === 1){
          const user: User = res.data;
          localStorage.setItem('user', JSON.stringify(user));
          this.userSubject.next(user);
        }
        return res;
      })
    );
  }

  logout()
  {
    localStorage.removeItem('user');  
    this.userSubject.next(null);  
  }*/
} 