import { Component, OnInit } from '@angular/core';
import {ReviewService} from '../../service/review.service';
import {Review} from '../../interface/ireview';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-reviewview',
  templateUrl: './reviewView.component.html',
  styleUrls: ['./reviewView.component.css']
})
export class ReviewViewComponent implements OnInit {
  reviews:Review [];
  constructor(private reviewService:ReviewService) { }

  ngOnInit() {
    this.reviewService.getAll().pipe(first())
    .subscribe(
        data => {
          this.reviews = data;
            console.log(data);
        },
        error => {
            console.log(error);
        });
      }
}
