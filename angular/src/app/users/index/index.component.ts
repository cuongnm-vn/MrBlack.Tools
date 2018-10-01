import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { PagedResultDtoOfUserDto, UserDto, UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { merge, of } from 'rxjs';

import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { SelectionModel } from '@angular/cdk/collections';
import { zipObject } from 'lodash';

@Component({
    selector: 'app-index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss']
})
export class IndexComponent extends PagedListingComponentBase<UserDto> implements OnInit, AfterViewInit {

    displayedColumns = ['id', 'name', 'emailAddress'];
    data: UserDto[] = [];
    selection = new SelectionModel<UserDto>(true, []);

    constructor(injector: Injector, private _userService: UserServiceProxy) {
        super(injector);
    }
    ngOnInit() {

    }
    ngAfterViewInit(): void {

        this.dataSources.sort = this.sort;
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

        merge(this.sort.sortChange, this.paginator.page)
            .pipe(
                startWith({}),
                switchMap(() => {
                    setTimeout(() => this.isTableLoading = true, 0);
                    const sort = this.sort.active ? zipObject([this.sort.active], [this.sort.direction]) : {};
                    return this._userService.getAll('', JSON.stringify(sort), this.paginator.pageIndex, this.paginator.pageSize);
                }),
                map((data: PagedResultDtoOfUserDto) => {
                    setTimeout(() => this.isTableLoading = false, 500);
                    this.totalItems = data.totalCount;
                    return data.items;
                }),
                catchError(() => {
                    setTimeout(() => this.isTableLoading = false, 500);
                    return of([]);
                })
            ).subscribe(data => this.dataSources.data = data);
    }

    isAllSelected() {
        const numSelected = this.selection.selected.length;
        const numRows = this.dataSources.data.length;
        return numSelected === numRows;
    }

    masterToggle() {
        this.isAllSelected() ?
            this.selection.clear() :
            this.dataSources.data.forEach((row: UserDto) => this.selection.select(row));
    }
}
