import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import Routes from '../routes/Routes';
import ContentContext from '../contexts/ContentContext';
import LabelsContext from '../contexts/LabelsContext';

const Footer: React.FC = () => {
  const { footerItems } = useContext(ContentContext);
  const labels = useContext(LabelsContext);
  return (
    <FooterContainer>
      {footerItems.map(item =>
        item.isExternal ? (
          <a
            key={item.label}
            href={item.url}
            target="_blank"
            rel="noopener noreferrer"
          >
            {labels[item.label]}
          </a>
        ) : (
          <Link key={item.label} to={Routes[item.routeAlias]}>
            {labels[item.label]}
          </Link>
        ),
      )}
    </FooterContainer>
  );
};

const FooterContainer = styled.footer`
  margin-top: 25px;
  a {
    margin-right: 15px;
    color: #ffffff;
  }
  background-color: ${props => props.theme.colors.secondary};
  border-top: solid ${props => props.theme.colors.primary};
  flex-shrink: 0;
  height: 75px;
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-flow: row wrap;
`;
export default Footer;
