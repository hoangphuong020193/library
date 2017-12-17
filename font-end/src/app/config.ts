declare var ENV: string;
class ApiWareHouse {
    private domain: string;
    public get Domain(): string {
        return this.domain;
    }

    private homeUrl: string;
    public get HomeUrl(): string {
        return this.homeUrl;
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

    public constructor() {
        switch (ENV) {
            case 'production':
                this.domain = '';
                this.protocol = '';
                this.apiEndPoint = '';
                this.avatarUrl = '';
                this.homeUrl = '';
                break;
            case 'development':
                this.protocol = 'http://';
                this.apiEndPoint = 'localhost:5000/api/';
                this.avatarUrl = '';
                this.homeUrl = '';
                break;
        }
    }
}

// tslint:disable-next-line:max-classes-per-file
export class Config {

    public static ServiceTimeout: number = 60000;
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

    private static apiWareHouse: ApiWareHouse = new ApiWareHouse();
}

// tslint:disable-next-line:typedef
export const PathController = {
    Account: 'account'
};
