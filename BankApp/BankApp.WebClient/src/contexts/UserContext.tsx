import React from 'react';

export interface User {
  id: number;
  name: string;
  login: string;
}

export interface UserControls {
  user?: User;
  login: (user: User, password: string) => void;
  logout: () => void;
}
const UserContext = React.createContext<UserControls>({} as UserControls);
UserContext.displayName = 'UserContext';
export default UserContext;
