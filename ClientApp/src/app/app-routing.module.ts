import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { RegisterComponent } from './authentication/register/register.component';
import { IndexComponent } from './dashboard/index/index.component';
import { AuthenticationService } from './services/authentication.service';

const routes: Routes = [
  {
    path:"account/register",component:RegisterComponent
  },
  {
    path: "account/login", component: LoginComponent
  },
  {
    path: "dashboard", component: IndexComponent,
    canActivate: [AuthenticationService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
