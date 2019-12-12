import { Component, OnInit } from "@angular/core";
import { User } from "../../interface/iuser";
import { FormBuilder, FormGroup } from "@angular/forms";
import { AuthService } from "../../service/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  newUser: User;
  registerForm: FormGroup;
  selectedFile = null;


  constructor(
    private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private Router: Router,
    private http: HttpClient
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
  }
  onUpload() {
    // this.http is the injected HttpClient
    const uploadData = new FormData();
    uploadData.append('myFile', this.selectedFile, this.selectedFile.name);
    this.http.post('my-backend.com/file-upload', uploadData, {
      reportProgress: true,
      observe: 'events'
    })
      .subscribe(event => {
        console.log(event);});
  }
  onSubmit(user) {   
    console.warn("Submitted", user);
    this.AuthService.register(user).subscribe(user => {
      console.log(user);
      if (user) this.Router.navigateByUrl("/");
    });
    this.onUpload();
  }

}
