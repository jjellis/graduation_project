import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,   
    private router: Router
    ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      Email: '',
      Password:''
    });
  }

  onSubmit(loginData){
    console.log(loginData);
    if(this.loginForm.invalid){
      return;
    }
    this.authService
    .login(loginData.Email, loginData.Password) 
        .pipe(first())
        .subscribe(
            data => {
                this.router.navigateByUrl("/");
                console.log(data);
            },
            error => {
                console.log(error);
            });
          }
        }
