import { Component, OnInit } from "@angular/core";
import { User } from "../../interface/iuser";
import { FormBuilder, FormGroup } from "@angular/forms";
import { AuthService } from "../../service/auth.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  newUser: User;
  registerForm: FormGroup;
  
  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private Router: Router,
    // private imageService: RegisterComponent
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
        Id: "",
        Password: "",
    FirstName: "",
    LastName: "",
    Email: "",
    ProfileImage: "",
    Address: ""
    });
  }
  
  onFileChanged(event) {
    const file = event.target.files[0]
    console.log(file);
    
  }

  
  onSubmit(user) {   
    console.warn("Submitted", user);
    this.AuthService.register(user).subscribe(user => {
      console.log(user);
      console.log(user);
      if (user) this.Router.navigateByUrl("/");
    });
  }

}
