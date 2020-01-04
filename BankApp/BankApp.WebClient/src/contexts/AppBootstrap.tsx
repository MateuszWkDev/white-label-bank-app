import React, { useState, useEffect } from 'react';
import { ThemeProvider, DefaultTheme } from 'styled-components';
import GlobalStyle from '../styles/GlobalStyle';
import appTheme from '../styles/app-theme';
import ContentContext, { Content } from './ContentContext';
import LabelsContext, { Labels } from './LabelsContext';
import ContentService from '../services/ContentService';

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
  if (!loaded) return <div>Loading...</div>;
  return (
    <>
      <ThemeProvider theme={theme}>
        <ContentContext.Provider value={content as Content}>
          <LabelsContext.Provider value={labels as Labels}>
            <GlobalStyle />
            {children}
          </LabelsContext.Provider>
        </ContentContext.Provider>
      </ThemeProvider>
    </>
  );
};
export default AppBootstrap;
