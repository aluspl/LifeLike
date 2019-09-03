export default class UserRegister {
    Username: string;
    Password: string;
    ConfirmPassword: string;
    Email: string;
    Token: string;
    constructor(Username: string, Password: string, Email: string) {
        this.Username = Username;
        this.ConfirmPassword = Password;
        this.Password = Password;
        this.Email = Email;
    }
}
