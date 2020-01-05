import React from 'react';
import styled from 'styled-components';
import MainRouting from '../routes/MainRouting';

const Main: React.FC = () => {
  return (
    <MainContainer>
      <MainRouting />
    </MainContainer>
  );
};

const MainContainer = styled.main`
  margin: 20px;
`;
export default Main;
