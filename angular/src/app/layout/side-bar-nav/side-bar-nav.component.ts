import { Component, Injector, ViewEncapsulation } from '@angular/core';

import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
  selector: 'app-side-bar-nav',
  templateUrl: './side-bar-nav.component.html',
  styleUrls: ['./side-bar-nav.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

  menuItems: MenuItem[] = [
    new MenuItem(this.l('HomePage'), '', 'home', '/app/dashboard'),

    new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
    new MenuItem(this.l('Users'), 'Pages.Users', 'people', '', [
      new MenuItem(this.l('Users'), '', '', '/app/users/index'),
      new MenuItem(this.l('Settings'), '', '', '/app/users/settings'),
    ]),
    new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
    new MenuItem(this.l('About'), '', 'info', '/app/about'),

    new MenuItem(this.l('MultiLevelMenu'), '', 'menu', '', [
      new MenuItem('ASP.NET Boilerplate', '', '', '', []),
      new MenuItem('ASP.NET Zero', '', '', '', [])
    ])
  ];

  constructor(
    injector: Injector
  ) {
    super(injector);
  }

  showMenuItem(menuItem): boolean {
    if (menuItem.permissionName) {
      return this.permission.isGranted(menuItem.permissionName);
    }

    return true;
  }
}
