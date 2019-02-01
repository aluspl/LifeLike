export default class MenuItem {
    Id: number;
    Controller: string;
    Action: string;
    Name: string;
    Icon: string;

    // get NavLink(): string {
    //      return '/'.concat(this.Controller).concat('/').concat(this.Action);
    // }
    // get Glyph(): string {
    //      return'fas fa-'.concat(this.Icon);
    // }
}
