import React, { useContext, useState } from 'react';
import { Link, NavLink as RRNavLink } from 'react-router-dom';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavbarText,
  NavLink,
} from 'reactstrap';
import styled from 'styled-components';
import Routes from '../routes/Routes';
import ContentContext from '../contexts/ContentContext';
import LabelsContext from '../contexts/LabelsContext';

const Header: React.FC = () => {
  const { navbarItems } = useContext(ContentContext);
  const labels = useContext(LabelsContext);
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);
  return (
    <NavbarContainer color="light" light expand="md">
      <NavbarBrand href="/">{labels.appName}</NavbarBrand>
      <NavbarToggler onClick={toggle} />
      <Collapse isOpen={isOpen} navbar>
        <Nav className="mr-auto" navbar>
          {navbarItems.map(item => {
            return (
              <NavLink
                key={Routes[item.routeAlias]}
                tag={RRNavLink}
                exact
                to={Routes[item.routeAlias]}
                activeClassName="active"
              >
                {labels[item.label]}
              </NavLink>

              // <li key={Routes[item.routeAlias]}>
              //   <Link to={Routes[item.routeAlias]}>{labels[item.label]}</Link>
              // </li>
            );
          })}
        </Nav>
        <NavbarText>Simple Text</NavbarText>
      </Collapse>
    </NavbarContainer>
  );
};

const NavbarContainer = styled(Navbar)`
  border-bottom: solid;
  border-bottom-color: ${props => props.theme.colors.primary};
  ul.navbar-nav > a.active.nav-link {
    color: ${props => props.theme.colors.primary};
  }
`;
export default Header;
