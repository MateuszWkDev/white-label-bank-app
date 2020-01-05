import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Routes from './Routes';
import HomePage from '../pages/Home';
import AboutPage from '../pages/About';
import TransactionPage from '../pages/Transaction';
import LoginPage from '../pages/Login';
import DashboardPage from '../pages/Dashboard';

const MainRouting: React.FC = () => {
  return (
    <Switch>
      <Route path={Routes.about}>
        <AboutPage />
      </Route>
      <Route path={Routes.dashboard}>
        <DashboardPage />
      </Route>
      <Route path={Routes.transaction}>
        <TransactionPage />
      </Route>
      <Route path={Routes.login}>
        <LoginPage />
      </Route>
      <Route path={Routes.home}>
        <HomePage />
      </Route>
    </Switch>
  );
};

export default MainRouting;
