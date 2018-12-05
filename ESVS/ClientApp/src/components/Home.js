import React, { Component } from 'react';
import {Grid} from "react-bootstrap";

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>
          МАКСИМУМ РЕАКТА, БРАТИШКА
        </h1>
        <iframe width="800" height="500" src="https://www.youtube.com/embed/GSYyGUvMXI0" frameBorder="0"
                allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
                allowFullScreen></iframe>
      </div>
    );
  }
}
