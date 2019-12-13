import { Component, OnInit, OnDestroy} from '@angular/core';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {RestaurantService} from '../../service/restaurant.service';
import {Restaurant} from '../../interface/irestaurant';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  Restaurants:Restaurant [];
  constructor(private route:ActivatedRoute, private restaurantService: RestaurantService, private router:Router) { }

  ngOnInit() {
    this.restaurantService.getAll().pipe(first())
    .subscribe(
        data => {
          this.Restaurants = data;
         
        },

        error => {
            console.log(error);
        });
  }

  /* search(text: string, pipe: PipeTransform): Country[] {
    return COUNTRIES.filter(country => {
      const term = text.toLowerCase();
      return country.name.toLowerCase().includes(term)
          || pipe.transform(country.area).includes(term)
          || pipe.transform(country.population).includes(term);
    });
  }*/

}
