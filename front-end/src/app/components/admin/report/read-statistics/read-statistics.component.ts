import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';

@Component({
    selector: 'read-statistics',
    templateUrl: './read-statistics.component.html'
})
export class ReadStatisticsComponent implements OnInit {

    private startDate: moment.Moment = moment(moment().format('YYYY-MM-01'));
    private endDate: moment.Moment = moment().endOf('month');

    constructor() { }

    public ngOnInit(): void { }

    private selectStartDate(date: moment.Moment): void {
        this.startDate = moment(date);
        // this.getTopBook(1);
    }

    private selectEndDate(date: moment.Moment): void {
        this.endDate = moment(date);
        // this.getTopBook(1);
    }
}
