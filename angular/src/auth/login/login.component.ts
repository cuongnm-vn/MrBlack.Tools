import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AbpSessionService } from '@abp/session/abp-session.service';
import { AppComponentBase } from '@shared/app-component-base';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent extends AppComponentBase implements OnInit {

    frmLogin: FormGroup;
    submitted = false;

    constructor(injector: Injector, public loginService: LoginService, private _formBuilder: FormBuilder, private _router: Router, private _sessionService: AbpSessionService) {
        super(injector);
    }

    ngOnInit(): void {
        // $(this.cardBody.nativeElement).find('input:first').focus();
        console.log(this.loginService.authenticateModel);
        this.frmLogin = this._formBuilder.group({
            userNameOrEmailAddress: [this.loginService.authenticateModel.userNameOrEmailAddress, Validators.required],
            password: [this.loginService.authenticateModel.password, Validators.required]
        });
    }
    get f() { return this.frmLogin.controls; }
    get multiTenancySideIsTeanant(): boolean {
        return this._sessionService.tenantId > 0;
    }

    get isSelfRegistrationAllowed(): boolean {
        if (!this._sessionService.tenantId) {
            return false;
        }

        return true;
    }

    login(): void {
        this.submitted = true;
        console.log(this.frmLogin.controls);
        if (this.frmLogin.invalid) { return; }
        // this.submitting = true;

        this.loginService.authenticateModel = Object.assign(this.loginService.authenticateModel, this.frmLogin.value);

        this.loginService.authenticate(
            () => { console.log(); }, error => console.log(error)
        );
    }
}
