export default class Config {
  Id: number;
  Name: string;
  Value: string;
  DisplayName: string;
  Type: string;

  get IsVideo(): boolean {
    return this.Type === 'Video';
  }
  get IsText(): boolean {
    return this.Type === 'Text';
  }
 get  IsRss(): boolean {
    return this.Type === 'RSS';
  }
}
