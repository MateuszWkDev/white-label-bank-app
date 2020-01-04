import React from 'react';
import styled from 'styled-components';
import AppBootstrap from './contexts/AppBootstrap';

const App: React.FC = () => {
  return (
    <>
      <AppBootstrap>
        <Container>TEST</Container>
      </AppBootstrap>
    </>
  );
};
const Container = styled.div`
  color: ${props => props.theme.colors.primary};
`;
export default App;
