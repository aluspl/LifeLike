import * as React from "react";
import YouTube from 'react-youtube';
interface IPlayer {
    YoutubeId: string
}

class Player extends React.Component<IPlayer, any> {
    render() {
        return (
            <YouTube videoId={this.props.YoutubeId} />
          );
      }       
}

export default Player;