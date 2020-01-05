import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Routes from './Routes';
import HomePage from '../pages/Home';

const MainRouting: React.FC = () => {
  return (
    <Switch>
      <Route path={Routes.about}>
        <div>About</div>
      </Route>
      <Route path={Routes.dashboard}>
        <div>Dashboard</div>
      </Route>
      <Route path={Routes.transaction}>
        <div>Transaction</div>
      </Route>
      <Route path={Routes.login}>
        <div>Login</div>
      </Route>
      <Route path={Routes.home}>
        <HomePage />
      </Route>
    </Switch>
  );
};

export default MainRouting;
