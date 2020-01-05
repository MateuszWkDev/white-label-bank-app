import React, { useState } from 'react';
import styled from 'styled-components';
import { BrowserRouter as Router } from 'react-router-dom';
import { Spinner } from 'reactstrap';
import GlobalStyle from './styles/GlobalStyle';

import UserContextProviderWrapper from './contexts/UserContextProviderWrapper';
import ContentContextProviderWrapper from './contexts/ContentContextProviderWrapper';

const AppBootstrap: React.FC = ({ children }) => {
  const [loaded, setLoaded] = useState(false);
  return (
    <ContentContextProviderWrapper onLoaded={setLoaded}>
      <UserContextProviderWrapper>
        {loaded ? (
          <>
            <GlobalStyle />
            <Router>{children}</Router>
          </>
        ) : (
          <SpinnerContainer>
            <Spinner size="lg" color="primary" />
          </SpinnerContainer>
        )}
      </UserContextProviderWrapper>
    </ContentContextProviderWrapper>
  );
};

const SpinnerContainer = styled.div`
  .spinner-border {
    width: 20rem;
    height: 20rem;
    display: block;
    border-width: 2em;
  }
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  height: 100vh;
`;
export default AppBootstrap;
