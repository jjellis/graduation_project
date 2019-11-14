import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, BehaviorSubject } from "rxjs";
import { map } from "rxjs/operators";
import { Review } from '../interface/ireview';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  constructor(private http: HttpClient) { }
  private _url: string = "https://localhost:44366/api/Review";

  getAll(): Observable<Review[]>{
    return this.http.get<Review[]>(this._url);
  }
}
