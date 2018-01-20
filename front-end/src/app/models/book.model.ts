export class Book {
    public bookId: number;
    public bookCode: string;
    public bookName: string;
    public categoryId: number;
    public categoryName: string;
    public tag: string;
    public description: string;
    public amount: number;
    public amountAvailable: number;
    public author: string;
    public publisher: string;
    public supplier: string;
    public size: string;
    public format: string;
    public publicationDate: Date;
    public pages: number;
    public maximumDateBorrow: number;
    public favorite: boolean;
}

// tslint:disable-next-line:max-classes-per-file
export class BookInCart {
    public id: number;
    public bookId: number;
    public status: number;
    public modifiedDate: string;
}

// tslint:disable-next-line:max-classes-per-file
export class BookInCartDetail {
    public bookId: number;
    public bookCode: string;
    public bookName: string;
    public amount: number;
    public amountAvailable: number;
    public author: string;
    public status: number;
    public modifiedDate: string;
    public maximumDateBorrow: number;
    public returnDate: string;
}
