import React, { useState, useEffect } from 'react';
import { ThemeProvider, DefaultTheme } from 'styled-components';
import appTheme from '../styles/app-theme';
import ContentContext, { Content } from './ContentContext';
import LabelsContext, { Labels } from './LabelsContext';
import ContentControlsContext from './ContentControlsContext';
import ContentService from '../services/ContentService';
import AppConfig from '../AppConfig';

interface Props {
  onLoaded: (isLoaded: boolean) => void;
}
const ContentContextProviderWrapper: React.FC<Props> = ({
  children,
  onLoaded,
}) => {
  const [theme, setTheme] = useState<DefaultTheme>(appTheme);
  const [content, setContent] = useState<Content>();
  const [labels, setLabels] = useState<Labels>();
  const [lang, setLang] = useState<string>(AppConfig.defaultLang);
  const [company, setCompany] = useState<string>(AppConfig.defaultCompany);
  useEffect(() => {
    ContentService.getContent(lang, company).then(
      ([contentResponse, labelsResponse, themeResponse]) => {
        setTheme(themeResponse.data);
        setContent(contentResponse.data);
        setLabels(labelsResponse.data);
        onLoaded(true);
      },
    );
  }, [company, lang, onLoaded]);
  const contentControls = {
    currentLang: lang,
    currentCompany: company,
    setLang,
    setCompany,
  };
  return (
    <>
      <ContentControlsContext.Provider value={contentControls}>
        <ThemeProvider theme={theme}>
          <ContentContext.Provider value={content as Content}>
            <LabelsContext.Provider value={labels as Labels}>
              {children}
            </LabelsContext.Provider>
          </ContentContext.Provider>
        </ThemeProvider>
      </ContentControlsContext.Provider>
    </>
  );
};

export default ContentContextProviderWrapper;
