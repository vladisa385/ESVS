import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './pages/Home';
import { About } from './pages/About';
import { Contacts } from './pages/Contacts';
import { ESVS } from './pages/ESVS';
import { Error } from './pages/Error';
import { Register } from './pages/Register';

export default class App extends Component {
  render() {
    return (
      <Layout>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route exact path='/about' component={About} />
          <Route exact path='/contacts' component={Contacts} />
          <Route exact path='/esvs' component={ESVS} />
          <Route exact path='/register' component={Register} />
          <Route render={() => <Error message={'Страница не найдена.'} /> } />
          </Switch>
        </Layout>
    );
  }
}
