import { Component, OnInit } from "@angular/core";
import { User } from "../../interface/iuser";
import { FormBuilder, FormGroup } from "@angular/forms";
import { AuthService } from "../../service/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  newUser: User;
  registerForm: FormGroup;
  selectedFile = null;

  constructor(private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private Router: Router,
    private http: HttpClient) { 
      this.registerForm = this.formBuilder.group({
        Password: "",
    FirstName: "",
    LastName: "",
    Email: "",
    ProfileImage: "",
    Address: ""
      });
    }
  
  ngOnInit() {
    let currentUser = this.AuthService.currentUserValue;
    
    
  }

}
