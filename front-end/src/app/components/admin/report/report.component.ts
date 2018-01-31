import { Component, OnInit } from '@angular/core';
import { DropDownData } from '../../common/dropdown/dropdown.component';

@Component({
    selector: 'report',
    templateUrl: './report.component.html'
})
export class ReportComponent implements OnInit {
    private listData: DropDownData[] = [];
    private typeSelected: number = ReportType.DebtBook;
    private ReportType: any = ReportType;

    constructor() { }

    public ngOnInit(): void {
        this.listData.push(new DropDownData(ReportType.DebtBook, 'Bạn đọc nợ sách'));
    }

    private selectType(type: DropDownData): void {
        this.typeSelected = type.key;
    }
}

enum ReportType {
    DebtBook = 1,
}
