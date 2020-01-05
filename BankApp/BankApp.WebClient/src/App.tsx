import React from 'react';
import AppBootstrap from './AppBootstrap';
import Layout from './layout';

const App: React.FC = () => {
  return (
    <>
      <AppBootstrap>
        <Layout />
      </AppBootstrap>
    </>
  );
};
export default App;
