import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';
import { Client } from "../models/client";

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json' // Sirve para cuando hagamos solicitudes post le mandamos el encabezado
  })
}


@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  url: string = 'https://localhost:44388/api/client/'
  constructor(
    private _http: HttpClient
  ) { }

//Siempre que hagamos una solicitud a un servicio se usa Observable
getClientes(): Observable<Response>{
  return this._http.get<Response>(this.url);
  }

  getDocumentType(): Observable<Response>{
    return this._http.get<Response>(this.url+'documentType');
    }

add(client: Client): Observable<Response>{
  console.log(client);
  return this._http.post<Response>(this.url, client, httpOption);
  }

edit(client: Client): Observable<Response>{
  console.log(client);
  return this._http.put<Response>(this.url, client, httpOption);
  }

  delete(cliId: number): Observable<Response>{
  return this._http.delete<Response>(`${this.url}?cliId=${cliId}`);
  }

}