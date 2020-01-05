import React, { useContext } from 'react';
import { Route, Redirect } from 'react-router-dom';
import UserContext from '../contexts/UserContext';
import Routes from './Routes';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
const PrivateRoute: React.FC<any> = ({ children, ...rest }) => {
  const { user } = useContext(UserContext);
  return (
    <Route
      // eslint-disable-next-line react/jsx-props-no-spreading
      {...rest}
      render={({ location }) =>
        user ? (
          children
        ) : (
          <Redirect
            to={{
              pathname: Routes.login,
              state: { from: location },
            }}
          />
        )
      }
    />
  );
};

export default PrivateRoute;
