import React, { useState, useEffect } from 'react';
import styled, { ThemeProvider, DefaultTheme } from 'styled-components';
import { BrowserRouter as Router } from 'react-router-dom';
import { Spinner } from 'reactstrap';
import GlobalStyle from './styles/GlobalStyle';
import appTheme from './styles/app-theme';
import ContentContext, { Content } from './contexts/ContentContext';
import LabelsContext, { Labels } from './contexts/LabelsContext';
import ContentService from './services/ContentService';

const AppBootstrap: React.FC = ({ children }) => {
  const [loaded, setLoaded] = useState(false);
  const [theme, setTheme] = useState<DefaultTheme>(appTheme);
  const [content, setContent] = useState<Content>();
  const [labels, setLabels] = useState<Labels>();
  useEffect(() => {
    ContentService.GetContent().then(
      ([contentResponse, labelsResponse, themeResponse]) => {
        setTheme(themeResponse.data);
        setContent(contentResponse.data);
        setLabels(labelsResponse.data);
        setLoaded(true);
      },
    );
  }, []);
  if (!loaded)
    return (
      <SpinnerContainer>
        <Spinner size="lg" color="primary" />
      </SpinnerContainer>
    );
  return (
    <>
      <ThemeProvider theme={theme}>
        <ContentContext.Provider value={content as Content}>
          <LabelsContext.Provider value={labels as Labels}>
            <GlobalStyle />
            <Router>{children}</Router>
          </LabelsContext.Provider>
        </ContentContext.Provider>
      </ThemeProvider>
    </>
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
