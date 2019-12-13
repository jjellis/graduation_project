import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './component/header/header.component';
import { LoginComponent } from './component/login/login.component';
import { ProfileComponent } from './component/profile/profile.component';
import { NavComponent } from './component/nav/nav.component';
import { FooterComponent } from './component/footer/footer.component';
import { SearchComponent } from './component/search/search.component';
import { FavoritesComponent } from './component/favorites/favorites.component';
import { ReviewViewComponent } from './component/reviewView/reviewView.component';
import { RegisterComponent } from './component/register/register.component';
import { AuthService } from './service/auth.service';
import { HttpClientModule} from "@angular/common/http";
import { RestaurantViewComponent } from './restaurantView/restaurantView.component';
import { RestaurantService } from './service/restaurant.service';
import {ReviewService} from './service/review.service'
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {MatToolbarModule, MatIconModule, MatSidenavModule, MatListModule, MatButtonModule, MatMenuModule } from  '@angular/material';
import { RestaurantsByTypeViewComponent } from './component/restaurants-by-type-view/restaurants-by-type-view.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    ProfileComponent,
    NavComponent,
    FooterComponent,
    SearchComponent,
    FavoritesComponent,
    ReviewViewComponent,
    RegisterComponent,
    RestaurantViewComponent,
    RestaurantsByTypeViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    FormsModule, 
    ReactiveFormsModule,
    HttpClientModule,
    MatMenuModule,
    MatIconModule,
    NgbModule,
    MatToolbarModule,  
    MatSidenavModule,
    MatListModule,
    MatButtonModule    
  ],
  providers: [AuthService, RestaurantService, ReviewService],
  bootstrap: [AppComponent]
})
export class AppModule { }
