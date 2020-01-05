import React from 'react';

export interface ContentControls {
  currentLang: string;
  currentCompany: string;
  setLang: (lang: string) => void;
  setCompany: (copmany: string) => void;
}
const ContentControlsContext = React.createContext<ContentControls>(
  {} as ContentControls,
);
ContentControlsContext.displayName = 'ContentControls';
export default ContentControlsContext;
