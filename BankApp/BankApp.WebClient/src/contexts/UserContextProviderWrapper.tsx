import React, { useState, useCallback } from 'react';
import UserContext, { User } from './UserContext';
import ContentService from '../services/ContentService';
import HttpClientService from '../services/HttpClientService';

const UserContextProviderWrapper: React.FC = ({ children }) => {
  const [user, setUser] = useState<User | undefined>(undefined);
  const login = useCallback((userData, password) => {
    setUser(userData);
    HttpClientService.configureBasicAuth({
      username: userData.login,
      password,
    });
    ContentService.getContent();
  }, []);
  const logout = useCallback(() => setUser(undefined), []);

  return (
    <UserContext.Provider
      value={{
        user,
        login,
        logout,
      }}
    >
      {children}
    </UserContext.Provider>
  );
};

export default UserContextProviderWrapper;
