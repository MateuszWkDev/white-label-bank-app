import React, { useContext } from 'react';
import styled from 'styled-components';
import ContentContext from '../../contexts/ContentContext';
import HomePageCard from './HomePageCard';

const HomePage: React.FC = () => {
  const { homePageItems } = useContext(ContentContext);
  return (
    <HomePageContainer>
      {homePageItems.map(item => (
        <HomePageCard item={item} />
      ))}
    </HomePageContainer>
  );
};

const HomePageContainer = styled.div`
  display: flex;
  flex-flow: column wrap;
  align-items: center;
  justify-content: space-evenly;
  div {
    margin-bottom: 25px;
  }
`;
export default HomePage;
