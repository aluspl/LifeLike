export default class MenuItem
{    

    
    constructor()
    {
        
        console.log('Link: '+this.Link);
        console.log('Glyph: '+this.IconClass);

    }
    
    IconClass: string;

    Id: number;
    Controller: string;
    Action: string; 
    Name: string;
    IconName: string;
    Link: string;


}