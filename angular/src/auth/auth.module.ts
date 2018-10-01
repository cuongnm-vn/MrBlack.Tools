import { AuthComponent } from './auth.component';
import { AuthRoutingModule } from './auth-routing.module';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login/login.service';
import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    SharedModule
  ],
  declarations: [LoginComponent, AuthComponent],
  providers: [
    LoginService
  ]
})
export class AuthModule { }
