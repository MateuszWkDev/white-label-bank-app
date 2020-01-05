import React, { useContext } from 'react';
import styled from 'styled-components';
import LabelsContext from '../../contexts/LabelsContext';
import { HomePageItem } from '../../contexts/ContentContext';
import AppConfig from '../../AppConfig';

interface Props {
  item: HomePageItem;
}
const HomePageCard: React.FC<Props> = ({ item }) => {
  const labels = useContext(LabelsContext);
  const title = labels[item.title];
  return (
    <CardContainer>
      <h6>{title}</h6>
      {item.contentType === 'youTubeMovie' && (
        <iframe
          title={title}
          width="100%"
          height="400"
          src={item.url}
          frameBorder="0"
          allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
          allowFullScreen
        />
      )}
      {item.contentType === 'image' && (
        <ImageContainer
          src={`${AppConfig.baseMediaUrl}${item.url}`}
          alt={title}
        />
      )}
      <p>{labels[item.text]}</p>
    </CardContainer>
  );
};

const CardContainer = styled.div`
  border-top: solid ${props => props.theme.colors.primary};
  width: 75%;
`;
const ImageContainer = styled.img`
  width: 50%;
  margin: auto;
  display: block;
`;

export default HomePageCard;
