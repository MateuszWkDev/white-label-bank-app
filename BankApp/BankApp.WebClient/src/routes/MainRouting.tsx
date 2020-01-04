import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Routes from './Routes';

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
      <Route path={Routes.home}>
        <div>Home</div>
      </Route>
    </Switch>
  );
};

export default MainRouting;
