import * as React from "react";
import YouTube from 'react-youtube';
interface IPlayer {
    YoutubeId: string
}

class Player extends React.Component<IPlayer, any> {
    GetLink()
    {
         return this.props.YoutubeId;
    }
    render() {
        const opts = {
          height: '390',
          width: '640',
          playerVars: { // https://developers.google.com/youtube/player_parameters
            autoplay: 1, 
          }
        };
     
        return (
            <YouTube 
              videoId={this.props.YoutubeId}
              opts={opts}
            />
          );
      }
          
}

export default Player;