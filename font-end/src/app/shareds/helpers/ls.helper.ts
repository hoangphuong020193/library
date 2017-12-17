import * as CryptoJs from 'crypto-js';

export class LsHelper {
    public static readonly LibraryStoragePassport: string = 'libraryStoragePassport';
    public static readonly UserStorage: string = 'userStore';

    public static save(key: string, data: any): boolean {
        try {
            const cipherData: CryptoJs.WordArray =
                CryptoJs.AES.encrypt(JSON.stringify(data), LsHelper.LibraryStoragePassport);
            this.libStorage.setItem(key, cipherData.toString());
            return true;
        } catch (err) {
            console.log('Error when serializing data ', err);
            return false;
        }
    }

    public static getItem(key: string): any {
        const cipherText: string = LsHelper.libStorage.getItem(key);
        if (!cipherText) { return undefined; }
        try {
            const bytes: CryptoJs.DecryptedMessage =
                CryptoJs.AES.decrypt(cipherText, LsHelper.LibraryStoragePassport);
            return JSON.parse(bytes.toString(CryptoJs.enc.Utf8));
        } catch (err) {
            console.log('Fail to decrypt user data ', err);
            return undefined;
        }
    }

    public static getUser(key: string = LsHelper.UserStorage): any {
        return LsHelper.getItem(key);
    }

    public static getAccessToken(): string {
        const user: any = LsHelper.getUser();
        return user ? user.accessToken : '';
    }

    public static clearStorage(): void {
        this.libStorage.clear();
    }

    public static removeKey(key: string): void {
        this.libStorage.removeItem(key);
    }

    private static libStorage: Storage = localStorage;
}
