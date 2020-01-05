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
  min-width: 320px;
  padding: 0;
  font-family: sans-serif;
  background-color:  ${props => props.theme.colors.bodyBackground};
}

.btn.btn-secondary, .btn.btn-secondary:hover, .btn.btn-secondary:focus, 
.btn.btn-secondary:active,.btn.btn-secondary:not(:disabled):not(.disabled):active, .show>.btn.btn-secondary.dropdown-toggle {
  background-color: ${props => props.theme.colors.secondary};
  border-color: ${props => props.theme.colors.secondary};
}
.btn.btn-primary, .btn.btn-primary:hover, .btn.btn-primary:focus, 
.btn.btn-primary:active,.btn.btn-primary:not(:disabled):not(.disabled):active, .show>.btn.btn-primary.dropdown-toggle {
  background-color: ${props => props.theme.colors.primary};
  border-color: ${props => props.theme.colors.primary};
}
.dropdown-menu.show {
  min-width: unset;
  width:60px;
  button.dropdown-item {
    padding: .25rem 0;
  }
}
nav.bg-light {
    background-color: ${props =>
      props.theme.colors.headerBackground} !important;
}
`;

export default GlobalStyle;
