import React from 'react';

export interface Labels {
  homeNav: string;
  aboutNav: string;
  dashboardNav: string;
  transactionNav: string;
  reactPage: string;
  netCorePage: string;
  appName: string;
  aboutTitle: string;
  aboutContent: string;
  logoAlt: string;
  loginPageInfo: string;
  login: string;
  password: string;
  submitButton: string;
  logoutButton: string;
  transactionHeader: string;
  fromAccountNumber: string;
  toAccountNumber: string;
  amount: string;
  dashboardHeader: string;
  accountsSubHeader: string;
  transactionsSubHeader: string;
  accountName: string;
  accountNumber: string;
  accountBalance: string;
  fromAccount: string;
  toAccount: string;
}
const LabelsContext = React.createContext<Labels>({} as Labels);
LabelsContext.displayName = 'LabelsContext';
export default LabelsContext;
