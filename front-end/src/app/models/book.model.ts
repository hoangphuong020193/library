export class Book {
    public bookId: number;
    public bookCode: string;
    public bookName: string;
    public categoryId: number;
    public categoryName: string;
    public categoryType: string;
    public tag: string;
    public description: string;
    public amount: number;
    public amountAvailable: number;
    public author: string;
    public publisherId: number;
    public publisher: string;
    public supplierId: number;
    public supplier: string;
    public size: string;
    public format: string;
    public publicationDate: Date;
    public pages: number;
    public maximumDateBorrow: number;
    public favorite: boolean;
    public dateImport: Date;
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

// tslint:disable-next-line:max-classes-per-file
export class SearchBookResult {
    public total: number;
    public listBooks: Book[];

    constructor(listBooks: Book[]) {
        this.listBooks = listBooks;
    }
}
