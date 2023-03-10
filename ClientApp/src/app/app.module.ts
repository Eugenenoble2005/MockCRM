 import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './authentication/register/register.component';
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { FormsModule } from "@angular/forms";
import { UserService } from './services/user.service';
import { ApiService } from './services/api.service';
import { HttpClientModule } from "@angular/common/http";
import { LoginComponent } from './authentication/login/login.component';
import { IndexComponent } from './dashboard/index/index.component';
import { CookieService } from "ngx-cookie-service";
import { MatGridListModule } from "@angular/material/grid-list"
import { DataService } from './services/data.service';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    IndexComponent
  ],
  imports: [
    BrowserModule,
    MatToolbarModule,
    HttpClientModule,
    MatTableModule,
    AppRoutingModule,
    FormsModule,
    MatGridListModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    BrowserAnimationsModule
  ],
  providers: [UserService, ApiService,CookieService,DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
