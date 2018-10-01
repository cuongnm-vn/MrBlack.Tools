import { MatButtonModule, MatIconModule, MatListModule, MatSidenavModule, MatToolbarModule } from '@angular/material';

import { AppComponent } from '@app/app.component';
import { AppRoutingModule } from '@app/app-routing.module';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { LayoutModule } from '@angular/cdk/layout';
import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { SideBarNavComponent } from './layout/side-bar-nav/side-bar-nav.component';

@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule,
    SharedModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
  declarations: [AppComponent, DashboardComponent, SideBarNavComponent]
})
export class AppModule { }
