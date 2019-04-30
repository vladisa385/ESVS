import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Redirect } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './pages/Home';
import { About } from './pages/About';
import { Contacts } from './pages/Contacts';
import { ESVS } from './pages/ESVS';
import { Error } from './pages/Error';
import { Register } from './pages/Register';
import { deleteCookie, getCookie, setCookie } from './utils/cookie';


export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      authorizedAs: '',
      wide: false
    };
    this.setAuthorizedAs = this.setAuthorizedAs.bind(this);
  }

  componentWillMount() {
    let cookie = getCookie('id');
    if (typeof (cookie) !== 'undefined') {
      fetch('http://localhost:33333/api/Account/Get/' + cookie, {
        method: 'GET',
        credentials: 'include',
        headers: { 'Accept' : 'application/json' }
      })
        .then(res => {
          if (res.ok) {
            res.json()
              .then(json => this.setState({ authorizedAs: json['userName'] }));
          }
          else deleteCookie('id');
        })
        .catch(err => console.error(err));
    }
  }

  // Callback для авторизации
  setAuthorizedAs(login, id, rememberMe) {
    this.setState({ authorizedAs : login });
    const cookie = 'id';
    if (login) {
      let expires = rememberMe ? 1209600 : 0; // Куки на 2 недели
      setCookie(cookie, id, { path: '/', expires: expires});
    }
    else deleteCookie(cookie);
  }

  render() {
    const goWide = () => this.setState({ wide: true });
    const revertWide = () => this.setState({ wide: false });

    return (
      <Layout authorizedAs={this.state.authorizedAs}
              setAuthorizedAs={this.setAuthorizedAs}
              wide={this.state.wide}>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route exact path='/about' component={About} />
          <Route exact path='/contacts' component={Contacts} />
          <Route exact path='/esvs' render={(props) => this.state.authorizedAs ?
            <ESVS goWide={goWide} revertWide={revertWide}/>
            :
            <Redirect to={{ pathname: '/', state: { from: props.location } }} /> }
          />
          <Route exact path='/register' component={Register} />
          <Route render={() => <Error message={'Страница не найдена.'} />} />
        </Switch>
      </Layout>
    );
  }
}
