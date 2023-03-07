import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public formLoading?: boolean;
  public constructor(public userService: UserService, public router: Router) { }
  public Register(data: Array<string>) {
    this.formLoading = true
    this.userService.create(data).subscribe(rez => {
      this.formLoading = false
      if (!rez.status) {
        alert(rez.errors?.[0]?.errorMessage)
      }
      else {
        this.router.navigate(["account/login"]);
      }
    })
  }
}
