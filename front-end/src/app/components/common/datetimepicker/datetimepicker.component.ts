import {
    Component, Directive, ElementRef, EventEmitter, HostListener,
    Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { DayComponent, ObjectDay } from './day/day.component';
import { MonthComponent, ObjectMonth } from './month/month.component';
import { ObjectYear, YearComponent } from './year/year.component';
import { JQueryHelper } from '../../../shareds/helpers/jquery.helper';
import { KeyCode } from '../../../shareds/enums/keycode.enum';
import { Format } from '../../../shareds/constant/format.constant';

@Component({
    selector: '[datetimepicker], datetimepicker',
    templateUrl: './datetimepicker.component.html'
})

export class DateTimePickerComponent implements OnInit, OnChanges {
    // Input
    @Input('minDate') public minDate: moment.Moment = null;
    @Input('maxDate') public maxDate: moment.Moment = null;
    @Input('setDate') public setDate: moment.Moment = null;
    @Input('format') public format: string = Format.DateFormat;
    @Input('disabled') public disabled: boolean = false;
    @Input('showIcon') public showIcon: boolean = true;
    @Input('placeholder') public placeholder: string = '';

    // Output
    @Output('selectedDateEmit') public selectedDateEmit: EventEmitter<any> = new EventEmitter();
    // tslint:disable-next-line:no-output-rename
    @Output('outFocus') public outFocusEmitter: EventEmitter<any> = new EventEmitter();
    // tslint:disable-next-line:no-output-rename
    @Output('focus') public focusEmitter: EventEmitter<any> = new EventEmitter();
    // tslint:disable-next-line:no-output-rename
    @Output('onTabPress') public tabPress: EventEmitter<any> = new EventEmitter();

    @ViewChild('dateInput') private dateInput: any;
    @ViewChild('datetimePickerPanel') private datetimePickerPanel: any;

    // Variable
    private readonly yearItems: number = 20;
    private Screen: any = Screen;
    private ShowScreen: any = Screen.Day;
    private daySelected: number = moment().date();
    private monthSelected: number = moment().month();
    private yearSelected: number = moment().year();
    private dateSelected: moment.Moment = moment();

    private pageCurrent: number = 0;
    private title: string;

    private pageDayCurrent: number = 0;
    private pageMonthCurrent: number = 0;
    private pageYearCurrent: number = 0;

    private dayTemp: number = moment().date();
    private monthTemp: number = moment().month();
    private yearTemp: number = moment().year();

    // Selector
    private dayInputClassString: string = 'day-input';
    private yearInputClassString: string = 'year-input';
    private monthInputClassString: string = 'month-input';
    private previousClassString: string = 'previous';
    private selectScreenClassString: string = 'select-screen';
    private nextClassString: string = 'next';
    private iconCalendarString: string = 'icon-calendar';
    private dateInputClassString: string = 'date-input';

    private datetimepickerPanelClass: string = '.datetimepicker-panel';
    private listHour: string[] = [];
    private listMinute: string[] = [];

    constructor(private elementRef: ElementRef) { }

    public ngOnInit(): void {
        this.dayTemp = this.daySelected;
        this.monthTemp = this.monthSelected;
        this.yearTemp = this.yearSelected;
        this.generateDate();
        JQueryHelper.onClickOutside('.datetimepicker-content', () => {
            if (this.datetimePickerPanel) {
                $(this.datetimePickerPanel.nativeElement).removeClass('show');
            }
        });
    }

    public ngOnChanges(changes: SimpleChanges): void {
        if (changes['setDate'] ||
            changes['maxDate'] ||
            changes['minDate']) {
            this.generateDate();
        }
    }

    private showDateTimePicker(): void {
        this.daySelected = this.daySelected;
        $(this.datetimepickerPanelClass).removeClass('show');
        if (!this.disabled) {
            $(this.datetimePickerPanel.nativeElement).addClass('show');
            this.focusEmitter.emit();
        }
    }

    private onPreviousPage(showScreen: any): void {
        const show = parseInt(this.ShowScreen, 10);
        switch (show) {
            case Screen.Day:
                this.pageDayCurrent--;
                break;
            case Screen.Month:
                this.pageMonthCurrent--;
                break;
            case Screen.Year:
                this.pageYearCurrent--;
            default:
                break;
        }

        this.changeTitle(true);
    }

    private onSelectScreen(showScreen: any): void {
        const show = parseInt(this.ShowScreen, 10);
        switch (show) {
            case Screen.Day:
                this.ShowScreen = Screen.Month;
                break;
            case Screen.Month:
                this.ShowScreen = Screen.Year;
                break;
            default:
                break;
        }
        this.changeTitle();
    }

    private onNextPage(showScreen: any): void {
        const show = parseInt(this.ShowScreen, 10);
        switch (show) {
            case Screen.Day:
                this.pageDayCurrent++;
                break;
            case Screen.Month:
                this.pageMonthCurrent++;
                break;
            case Screen.Year:
                this.pageYearCurrent++;
            default:
                break;
        }
        this.changeTitle(true);
    }

    private selectDay(day: ObjectDay): void {
        $(this.datetimePickerPanel.nativeElement).removeClass('show');
        this.daySelected = day.day;
        this.monthSelected = day.month;
        this.yearSelected = day.year;
        this.pageDayCurrent = 0;
        this.pageMonthCurrent = 0;
        this.pageYearCurrent = 0;
        this.changeTitle(this.ShowScreen);
        this.showOnInput();
    }

    private selectMonth(month: ObjectMonth): void {
        this.monthSelected = month.monthId;
        this.yearSelected = month.year;
        this.ShowScreen = Screen.Day;
        this.pageDayCurrent = 0;
        this.pageMonthCurrent = 0;
        this.changeTitle();
        this.showOnInput();
    }

    private selectYear(year: ObjectYear): void {
        this.yearSelected = year.year;
        this.ShowScreen = Screen.Month;
        this.pageMonthCurrent = 0;
        this.pageYearCurrent = 0;
        this.changeTitle();
        this.showOnInput();
    }

    private changeTitle(move: boolean = false): void {
        const newDate: Date = new Date(this.yearSelected, this.monthSelected, this.daySelected);
        const show = parseInt(this.ShowScreen, 10);
        switch (show) {
            case Screen.Day:
                if (!move) {
                    this.title = moment(newDate).format('MMMM') + ' - ' + newDate.getFullYear();
                } else {
                    newDate.setMonth(newDate.getMonth() + this.pageDayCurrent, 1);
                    this.title = moment(newDate).format('MMMM') + ' - ' + newDate.getFullYear();
                }
                if (this.yearSelected !== newDate.getFullYear()) {
                    this.pageMonthCurrent = newDate.getFullYear() - this.yearSelected;
                }
                break;
            case Screen.Month:
                this.title = (newDate.getFullYear() + this.pageMonthCurrent).toString();
                this.yearTemp = newDate.getFullYear() + this.pageMonthCurrent;
                break;
            case Screen.Year:
            default:
                if (!move) {
                    const newYear: number = this.yearTemp + this.yearItems - 1;
                    this.title = this.yearTemp + ' - ' + newYear;
                } else {
                    const startRange: number =
                        this.yearTemp + (this.yearItems * this.pageYearCurrent);
                    const endRange: number = startRange + this.yearItems - 1;
                    this.title = startRange + ' - ' + endRange;
                }
                break;
        }
    }

    private showOnInput(): void {
        const date: Date = new Date(this.yearSelected,
            this.monthSelected, this.daySelected);
        const ouputDate: string = moment(date).format(this.format);
        this.dateInput.nativeElement.value = ouputDate;
        this.selectedDateEmit.emit(moment(date));
        this.outFocusEmitter.emit();
    }

    private handleChangeInput(): void {
        const inputString: string = this.dateInput.nativeElement.value;
        const date: moment.Moment = moment(inputString, 'dd/mm/yyyy');
        if (date.isValid()) {
            this.daySelected = date.date();
            this.monthSelected = date.month();
            this.yearSelected = date.year();
            this.changeTitle();
        } else {
            this.dateInput.nativeElement.value = '';
        }
    }

    private focusOutInput(event: any): void {
        this.handleChangeInput();
    }

    private onKeyDown(event: any): void {
        const daysInCurrentMonth: number =
            new Date(this.yearSelected, this.monthSelected, 0).getDate();
        switch (event.keyCode) {
            case KeyCode.Enter:
                this.handleChangeInput();
                $(this.datetimePickerPanel.nativeElement).removeClass('show');
                break;
            case KeyCode.Tab:
                $(this.datetimePickerPanel.nativeElement).removeClass('show');
                this.tabPress.emit();
                break;
            case KeyCode.Up:
                this.daySelected -= 7;
                if (this.daySelected <= 0) { this.daySelected = 1; }
                break;
            case KeyCode.Down:
                this.daySelected += 7;
                if (this.daySelected >= daysInCurrentMonth) {
                    this.daySelected = daysInCurrentMonth - 1;
                }
                break;
            case KeyCode.Left:
                this.daySelected -= 1;
                if (this.daySelected <= 0) { this.daySelected = 1; }
                break;
            case KeyCode.Right:
                this.daySelected += 1;
                if (this.daySelected >= daysInCurrentMonth) {
                    this.daySelected = daysInCurrentMonth - 1;
                }
                break;
            default:
                break;
        }
    }

    private generateDate(): void {
        const date: moment.Moment = moment(this.setDate);
        this.dateSelected = this.setDate !== null ? date : moment();
        this.daySelected = this.dateSelected.date();
        this.monthSelected = this.dateSelected.month();
        this.yearSelected = this.dateSelected.year();
        this.changeTitle();
    }

    private parseDate(date: Date): string {
        return moment(date).format(this.format);
    }
}

enum Screen {
    Day = 0,
    Month = 1,
    Year = 2,
    Time = 3
}
