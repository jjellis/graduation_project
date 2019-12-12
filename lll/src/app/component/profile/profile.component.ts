import { Component, OnInit } from "@angular/core";
import { User } from "../../interface/iuser";
import { FormBuilder, FormGroup } from "@angular/forms";
import { AuthService } from "../../service/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient, HttpHeaders, HttpEventType } from "@angular/common/http";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  newUser: User;
  profileForm: FormGroup;
  selectedFile = null;
  currentUser:User; 
  httpOptions = {
    headers: new HttpHeaders({
      "Access-Control-Allow-Credentials": "true"
      
    })
  };
  constructor(private formBuilder: FormBuilder,
    private AuthService: AuthService,
    private Router: Router,
    private http: HttpClient) { 
     
      this.currentUser = this.AuthService.currentUserValue;
      this.profileForm = this.formBuilder.group({
        Password: "",
    FirstName: "",
    LastName: "",
    Email: "",
    ProfileImage: "",
    Address: ""
      });
 this.AuthService.currentUser.subscribe(data=>{
  this.currentUser.firstName = data.user.firstName;
  this.currentUser.address = data.user.address;
  this.currentUser.email = data.user.email;
  this.currentUser.lastName = data.user.lastName;
  this.currentUser.password  = data.user.password;
  this.currentUser.profileImage = data.user.profileImage;
  this.currentUser.id = data.user.id;
  console.log(data);
  console.log(this.currentUser.firstName);
  console.log(this.currentUser.profileImage);
}, error => {
  console.log(error);
});
     
    }
  
  ngOnInit() {
      
    this.profileForm.patchValue({
      
      FirstName: this.currentUser.firstName,
      Password: this.currentUser.password,
    LastName: this.currentUser.lastName,
    Email: this.currentUser.email,
    ProfileImage: this.currentUser.profileImage,
    Address: this.currentUser.address
      } );
      console.log(this.currentUser.password);
   
   
    
  }
  
    onFileChanged(event) {
      this.selectedFile = event.target.files[0]
    }

    onUpload() {
      // this.http is the injected HttpClient
      const uploadData = new FormData();
      uploadData.append('Image', this.selectedFile, this.selectedFile.name);
      uploadData.append('UserId', this.currentUser.id);
      console.log(uploadData.get('UserId'));
      console.log(uploadData.get('Image'));
      this.http.post('https://localhost:44366/api/auth/imagepost', uploadData, {
        reportProgress: true,
    observe: 'events'
      })
        .subscribe(event=>{
          if(event.type === HttpEventType.UploadProgress)
          console.log("Upload Progress: " + Math.round(event.loaded / event.total) * 100 + '%');
          else if (event.type === HttpEventType.Response)
          console.log(event);
        });
}
}
