import 'styled-components';

interface AppTheme {
  colors: {
    primary: string;
    secondary: string;
  };
}
declare module 'styled-components' {
  export interface DefaultTheme {
    colors: {
      primary: string;
      secondary: string;
      bodyBackground: string;
      headerBackground: string;
    };
  }
}
