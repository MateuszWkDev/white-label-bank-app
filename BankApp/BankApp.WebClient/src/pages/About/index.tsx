import React, { useContext } from 'react';
import styled from 'styled-components';
import LabelsContext from '../../contexts/LabelsContext';

const AboutPage: React.FC = () => {
  const labels = useContext(LabelsContext);
  return (
    <>
      <h4>{labels.aboutTitle}</h4>
      <ContentContainer>{labels.aboutContent}</ContentContainer>
    </>
  );
};

const ContentContainer = styled.p`
  white-space: pre-wrap;
`;
export default AboutPage;
