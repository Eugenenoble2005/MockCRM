import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CookieService } from "ngx-cookie-service";
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(public userService: UserService, private _cookie: CookieService, public _router: Router) {

  }
  public Login(data: Array<any>) {
    this.userService.login(data).subscribe(rez => {
      if (!rez.status) {
        alert("Wrong Credentials")
      }
      else {
        this._cookie.set("token", rez.token ?? "");
        window.location.href = "/dashboard";
      }
      console.log(rez);
    })
  }
}
