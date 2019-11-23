import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProfileComponent} from './component/profile/profile.component';
import {SearchComponent} from './component/search/search.component';
import {RestaurantViewComponent} from './restaurantView/restaurantView.component';


const routes: Routes = [
  {path: 'profile', component: ProfileComponent},
  {path: 'search', component: SearchComponent},
  {path: 'restaurant', component: RestaurantViewComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
