export default class UserLogin {
    UserName: string;
    Password: string;
    RememberMe: boolean;
    FirstName: string;
    LastName: string;
    Token: string;
    constructor(Username: string, Password: string) {
        this.UserName = Username;
        this.Password = Password;
    }
}
