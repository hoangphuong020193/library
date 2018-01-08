declare var ENV: string;
class ApiWareHouse {
    private domain: string;
    public get Domain(): string {
        return this.domain;
    }

    private protocol: string;
    public get Protocol(): string {
        return this.protocol;
    }

    private apiEndPoint: string;
    public get ApiEndPoint(): string {
        return this.apiEndPoint;
    }

    private avatarUrl: string;
    public get AvatarUrl(): string {
        return this.avatarUrl;
    }

    private appVersion: string;
    public get Version(): string {
        return this.appVersion;
    }

    public constructor() {
        this.appVersion = '1.0.5.1';
        switch (ENV) {
            case 'production':
                this.domain = '';
                this.protocol = 'http://';
                this.apiEndPoint = 'localhost:5000/api/';
                this.avatarUrl = '';
                break;
            case 'development':
            default:
                this.protocol = 'http://';
                this.apiEndPoint = 'localhost:5000/api/';
                this.avatarUrl = '';
                break;
        }
    }
}

// tslint:disable-next-line:max-classes-per-file
export class Config {
    public static ServiceTimeout: number = 60000;
    public static ApplyOverlayOnAutoComplete: boolean = true;
    public static TicketAreaLeaveStyle: string = 'click-outside';
    // public static TicketAreaLeaveStyle: string = 'mouse-leave';

    public static getAvatarApiUrl(employeeId: number): string {
        const url: string = this.apiWareHouse.AvatarUrl;
        return url + employeeId;
    }

    public static getPath(value: string): string {
        const apiCluster: string = this.apiWareHouse.Protocol + this.apiWareHouse.ApiEndPoint;
        if (Object.keys(PathController).find((key) => PathController[key] === value)) {
            return apiCluster + value;
        }
        return apiCluster;
    }

    public static getVerison(): string {
        return this.apiWareHouse.Version;
    }

    private static apiWareHouse: ApiWareHouse = new ApiWareHouse();
}

// tslint:disable-next-line:typedef
export const PathController = {
    Account: 'account',
    Book: 'book'
};
