import * as React from "react";

interface IPlayer {
    YoutubeId: string
}

class Player extends React.Component<IPlayer, any> {

    render() {
        const videoUrl = `http://www.youtube.com/embed/${this.props.YoutubeId}`;

        return (
            <div>
                <iframe className="responsive-embed-item" src={videoUrl}/>
            </div>
          );
      }       
}

export default Player;