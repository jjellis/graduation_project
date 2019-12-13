  import { Injectable } from '@angular/core';
  import { HttpClient, HttpHeaders } from "@angular/common/http";
  import { Observable, BehaviorSubject } from "rxjs";
  import { map } from "rxjs/operators";
import { Restaurant } from '../interface/irestaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  
  constructor(private http: HttpClient) { }
  private _url: string = "https://localhost:44366/api/restaurant";

  getAll(): Observable<Restaurant[]>{
    return this.http.get<Restaurant[]>(this._url);
  }
  get(id:number){
    return this.http.get<Restaurant>(this._url+"/"+id);
  }
}
