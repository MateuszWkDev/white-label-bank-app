import React from 'react';
import { Labels } from './LabelsContext';
import Routes from '../routes/Routes';

interface NavbarItem {
  routeAlias: keyof Routes;
  label: keyof Labels;
}

interface FooterItem extends NavbarItem {
  isExternal: boolean;
  url: string;
}
export interface Content {
  navbarItems: NavbarItem[];
  footerItems: FooterItem[];
}

const ContentContext = React.createContext<Content>({} as Content);
ContentContext.displayName = 'ContentContext';
export default ContentContext;
