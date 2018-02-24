export class UserNotReturnBook {
    public userId: number;
    public userName: string;
    public firstName: string;
    public lastName: string;
    public middleName: string;
    public requestId: number;
    public requestCode: string;
    public bookId: number;
    public bookCode: string;
    public bookName: string;
    public receivedDate: Date;
    public deadlineDate: Date;
}

// tslint:disable-next-line:max-classes-per-file
export class ReadStatistic {
    public userName: string;
    public firstName: string;
    public middleName: string;
    public lastName: string;
    public bookCode: string;
    public bookName: string;
    public categoryName: string;
    public libraryName: string;
    public noOfBorrow: number;
    public noOfReturn: number;
}
