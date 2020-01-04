import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import Routes from '../routes/Routes';
import ContentContext from '../contexts/ContentContext';
import LabelsContext from '../contexts/LabelsContext';

const Header: React.FC = () => {
  const { navbarItems } = useContext(ContentContext);
  const labels = useContext(LabelsContext);
  return (
    <nav>
      <ul>
        {navbarItems.map(item => {
          return (
            <li key={Routes[item.routeAlias]}>
              <Link to={Routes[item.routeAlias]}>{labels[item.label]}</Link>
            </li>
          );
        })}
      </ul>
    </nav>
  );
};

export default Header;
