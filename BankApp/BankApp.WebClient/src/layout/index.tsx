import React from 'react';
import styled from 'styled-components';
import Header from './Header';
import Main from './Main';
import Footer from './Footer';

const Layout: React.FC = () => {
  return (
    <>
      <ContentContainer>
        <Header />
        <Main />
      </ContentContainer>
      <Footer />
    </>
  );
};

const ContentContainer = styled.div`
  flex: 1 0 auto;
`;
export default Layout;
