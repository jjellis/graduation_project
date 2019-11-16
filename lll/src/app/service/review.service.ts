import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, BehaviorSubject} from "rxjs";
import{ first} from 'rxjs/operators';
import { map } from "rxjs/operators";
import { Review } from '../interface/ireview';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  constructor(private http: HttpClient) { }
  private _url: string = "https://localhost:44366/api/Review";
  private _url2: string = "https://localhost:44366/api/restaurant/";

  getAll(): Observable<Review[]>{
    return this.http.get<Review[]>(this._url);
  }

  getAllReviewsForRestaurant(id:number): Observable<Review[]>{
    debugger;
    this._url2 += id.toString;
    debugger;
    return this.http.get<Review[]>(this._url2+"reviews");
  }
}
