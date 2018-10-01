import { AfterViewInit, ChangeDetectorRef, Component, Injector, OnInit, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

import { AppAuthService } from '@shared/auth/app-auth.service';
import { AppComponentBase } from '@shared/app-component-base';
import { Observable } from 'rxjs';
import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';
import { map } from 'rxjs/operators';

@Component({
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent extends AppComponentBase implements OnInit, AfterViewInit {

    private viewContainerRef: ViewContainerRef;

    isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset).pipe(map(result => result.matches));
    shownLoginName: string = '';

    constructor(injector: Injector, private breakpointObserver: BreakpointObserver, private _authService: AppAuthService) {
        super(injector);
        this.shownLoginName = this.appSession.getShownLoginName();
        console.log(this.appSession);
    }

    ngOnInit(): void {

        SignalRAspNetCoreHelper.initSignalR();

        abp.event.on('abp.notifications.received', userNotification => {
            abp.notifications.showUiNotifyForUserNotification(userNotification);

            // Desktop notification
            // Push.create('AbpZeroTemplate', {
            //     body: userNotification.notification.data.message,
            //     icon: abp.appPath + 'assets/app-logo-small.png',
            //     timeout: 6000,
            //     onClick: function() {
            //         window.focus();
            //         this.close();
            //     }
            // });
        });
    }

    ngAfterViewInit(): void {
    }

    logout(): void {
        this._authService.logout();
    }

    onResize(event) {
        // exported from $.AdminBSB.activateAll
    }
}
