export default class UserLogin {
    UserName: string;
    Password: string;
    Firstname: string;
    Lastname: string;
    Email: string;
    Token: string;
    Info: string;
    constructor(Username: string, Password: string) {
        this.UserName = Username;
        this.Password = Password;
    }
}
