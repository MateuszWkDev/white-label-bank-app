import React from 'react';

export interface Content {
  navbar: [];
}

const ContentContext = React.createContext<Content>({} as Content);
ContentContext.displayName = 'ContentContext';
export default ContentContext;
