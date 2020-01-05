import React from 'react';
import { Labels } from './LabelsContext';
import Routes from '../routes/Routes';

export interface NavbarItem {
  routeAlias: keyof Routes;
  label: keyof Labels;
}

export interface FooterItem extends NavbarItem {
  isExternal: boolean;
  url: string;
}

export interface HomePageItem {
  title: keyof Labels;
  text: keyof Labels;
  contentType: 'youTubeMovie' | 'image' | undefined;
  url: string;
}
export interface Content {
  navbarItems: NavbarItem[];
  footerItems: FooterItem[];
  homePageItems: HomePageItem[];
  languages: string[];
  companies: string[];
  logoUrl: string;
}

const ContentContext = React.createContext<Content>({} as Content);
ContentContext.displayName = 'ContentContext';
export default ContentContext;
