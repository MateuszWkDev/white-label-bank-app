import React from 'react';

export interface Labels {
  loginButton: string;
}
const LabelsContext = React.createContext<Labels>({} as Labels);
LabelsContext.displayName = 'LabelsContext';
export default LabelsContext;
