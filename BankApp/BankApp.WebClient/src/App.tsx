import React from 'react';
import AppBootstrap from './AppBootstrap';
import Header from './layout/Header';
import Footer from './layout/Footer';
import Main from './layout/Main';

const App: React.FC = () => {
  return (
    <>
      <AppBootstrap>
        <Header />
        <Main />
        <Footer />
      </AppBootstrap>
    </>
  );
};
export default App;
