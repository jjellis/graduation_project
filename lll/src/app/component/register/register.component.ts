import { Component, OnInit } from "@angular/core";
import { User } from "../../interface/iuser";
import { FormBuilder, FormGroup } from "@angular/forms";
import { AuthService } from "../../service/auth.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit {
  newUser: User;
  registerForm: FormGroup;
  selectedFile: RegisterComponent;

  onFileChanged(event) {
    const file = event.target.files[0]
  }
  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private Router: Router,
    private imageService: RegisterComponent
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      password: " ",
      firstName: " ",
      lastName: " ",
      email: " "
    });
  }
  

  onSubmit(user) {   
    console.warn("Submitted", user);
    this.AuthService.register(user).subscribe(user => {
      console.log(user);
      if (user) this.Router.navigateByUrl("/");
    });
  }

}
