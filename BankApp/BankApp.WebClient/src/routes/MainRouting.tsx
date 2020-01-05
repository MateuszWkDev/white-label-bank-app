import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Routes from './Routes';
import HomePage from '../pages/Home';
import AboutPage from '../pages/About';
import TransactionPage from '../pages/Transaction';
import LoginPage from '../pages/Login';
import DashboardPage from '../pages/Dashboard';
import PrivateRoute from './PrivateRoute';

const MainRouting: React.FC = () => {
  return (
    <Switch>
      <Route path={Routes.about}>
        <AboutPage />
      </Route>
      <PrivateRoute path={Routes.dashboard}>
        <DashboardPage />
      </PrivateRoute>
      <PrivateRoute path={Routes.transaction}>
        <TransactionPage />
      </PrivateRoute>
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
