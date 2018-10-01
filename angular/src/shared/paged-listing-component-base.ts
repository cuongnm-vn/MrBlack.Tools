﻿import { AfterViewInit, Injector, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

import { AppComponentBase } from 'shared/app-component-base';

export class PagedResultDto {
    items: any[];
    totalCount: number;
}

export class EntityDto {
    id: number;
}

export class PagedRequestDto {
    skipCount: number;
    maxResultCount: number;
}

// tslint:disable-next-line:no-shadowed-variable
export abstract class PagedListingComponentBase<EntityDto> extends AppComponentBase {

    public pageSize: number = 10;
    public pageNumber: number = 1;
    public totalPages: number = 1;
    public totalItems: number;
    public isTableLoading = false;

    displayedColumns = [];
    dataSources = new MatTableDataSource();
    @ViewChild('paginator') paginator: MatPaginator;
    @ViewChild('sort') sort: MatSort;

    constructor(injector: Injector) {
        super(injector);
    }

    // ngAfterViewInit(): void {
    //     this.dataSources.sort = this.sorter;
    //     this.sorter.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    // }


    // ngOnInit(): void {
    //     this.refresh();
    // }

    // refresh(): void {
    //     this.getDataPage(this.pageNumber);
    // }

    // public showPaging(result: PagedResultDto, pageNumber: number): void {
    //     this.totalPages = ((result.totalCount - (result.totalCount % this.pageSize)) / this.pageSize) + 1;

    //     this.totalItems = result.totalCount;
    //     this.pageNumber = pageNumber;
    // }

    // public getDataPage(page: number): void {
    //     const req = new PagedRequestDto();
    //     req.maxResultCount = this.pageSize;
    //     req.skipCount = (page - 1) * this.pageSize;

    //     this.isTableLoading = true;
    //     this.list(req, page, () => {
    //         this.isTableLoading = false;
    //     });
    // }

    // protected abstract list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void;
    // protected abstract delete(entity: EntityDto): void;
}
