import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { NgModule } from '@angular/core';
import { SettingsComponent } from './settings/settings.component';
import { SharedModule } from '@shared/shared.module';
import { UsersComponent } from './users.component';
import { UsersRoutingModule } from './users-routing.module';

@NgModule({
  imports: [
    CommonModule,
    UsersRoutingModule,
    SharedModule
  ],
  declarations: [UsersComponent, IndexComponent, SettingsComponent]
})
export class UsersModule { }
