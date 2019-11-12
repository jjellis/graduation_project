  import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Restaurant } from '../interface/irestaurant';

@Injectable({
  providedIn: 'root'
})
export class RestrauntService {

  constructor(private http: HttpClient) { }
  private _url: string = "https://localhost:44366/api/restaurant";

  getAll(): Observable<Restaurant[]>{
    return this.http.get<Restaurant[]>(this._url);
  }
}
