import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProfileComponent} from './component/profile/profile.component';
import {SearchComponent} from './component/search/search.component';
import {RestaurantViewComponent} from './restaurantView/restaurantView.component';
import {RestaurantsByTypeViewComponent} from './component/restaurants-by-type-view/restaurants-by-type-view.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';


const routes: Routes = [
  {path:"login", component: LoginComponent},
  {path:"register", component: RegisterComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'search', component: SearchComponent},
  {path: 'restaurantsByType/:name', component: RestaurantsByTypeViewComponent},
  {path: 'restaurants/:id', component: RestaurantViewComponent}];
 
   

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
