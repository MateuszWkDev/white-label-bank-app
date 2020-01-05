import { createGlobalStyle } from 'styled-components';

const GlobalStyle = createGlobalStyle`
html, body, #root {
  height: 100%;
  margin: 0;
}
#root {
  display: flex;
  flex-direction: column;
}
body {
  padding: 0;
  font-family: sans-serif;
  background-color:  ${props => props.theme.colors.bodyBackground};
}`;

export default GlobalStyle;
