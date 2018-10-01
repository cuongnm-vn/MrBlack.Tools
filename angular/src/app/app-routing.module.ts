import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from '@app/app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AppComponent,
        children: [
          { path: 'dashboard', component: DashboardComponent, canActivate: [AppRouteGuard] },
          {
            path: 'users',
            loadChildren: 'app/users/users.module#UsersModule', canActivate: [AppRouteGuard]
          }
        ]
      },
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
