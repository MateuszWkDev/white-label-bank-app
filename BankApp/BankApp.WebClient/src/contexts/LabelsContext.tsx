import React from 'react';

export interface Labels {
  homeNav: string;
  aboutNav: string;
  dashboardNav: string;
  transactionNav: string;
  reactPage: string;
  netCorePage: string;
  appName: string;
}
const LabelsContext = React.createContext<Labels>({} as Labels);
LabelsContext.displayName = 'LabelsContext';
export default LabelsContext;
