import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'admin',
    templateUrl: './admin.component.html'
})
export class AdminComponent implements OnInit {

    private borrowReturnBookTab: number = 1;
    private bookManagementTab: number = 2;
    private debtListTab: number = 3;
    private selectedTab: number = this.borrowReturnBookTab;

    constructor() { }

    public ngOnInit() { }

    private selectTab(tab: number): void {
        this.selectedTab = tab;
    }
}
