import { Component, OnInit, Input } from '@angular/core';
import {ReviewService} from '../../service/review.service';
import {Review} from '../../interface/ireview';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-reviewview',
  templateUrl: './reviewView.component.html',
  styleUrls: ['./reviewView.component.css']
})
export class ReviewViewComponent implements OnInit {
  @Input() childReview:Review;
  constructor(private reviewService:ReviewService) { }

  ngOnInit() {
    
  }
}
