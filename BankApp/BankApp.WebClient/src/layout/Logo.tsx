import React, { useContext } from 'react';
import styled from 'styled-components';
import LabelsContext from '../contexts/LabelsContext';
import AppConfig from '../AppConfig';
import ContentContext from '../contexts/ContentContext';

const Logo: React.FC = () => {
  const labels = useContext(LabelsContext);
  const { logoUrl } = useContext(ContentContext);
  return (
    <ImageContainer
      src={`${AppConfig.baseMediaUrl}${logoUrl}`}
      alt={labels.logoAlt}
    />
  );
};

const ImageContainer = styled.img`
  width: 40px;
  height: 40px;
`;
export default Logo;
