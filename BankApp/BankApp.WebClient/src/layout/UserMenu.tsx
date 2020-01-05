import React, { useContext, useState, useCallback } from 'react';
import {
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Button,
} from 'reactstrap';
import styled from 'styled-components';
import ContentContext from '../contexts/ContentContext';
import LabelsContext from '../contexts/LabelsContext';
import UserContext from '../contexts/UserContext';
import ContentControlsContext from '../contexts/ContentControlsContext';

const UserMenu: React.FC = () => {
  const { languages, companies } = useContext(ContentContext);
  const contentControls = useContext(ContentControlsContext);
  const labels = useContext(LabelsContext);
  const { user, logout } = useContext(UserContext);
  const [langDropdownOpen, setLangDropdownOpen] = useState(false);
  const [companyDropdownOpen, setCompanyDropdownOpen] = useState(false);

  const toggleLang = useCallback(
    () => setLangDropdownOpen(prevState => !prevState),
    [],
  );
  const toggleCopmany = useCallback(
    () => setCompanyDropdownOpen(prevState => !prevState),
    [],
  );
  return (
    <UserMenuContainer>
      <Dropdown isOpen={langDropdownOpen} toggle={toggleLang}>
        <DropdownToggle caret>{contentControls.currentLang}</DropdownToggle>
        <DropdownMenu>
          {languages?.map(lang => (
            <DropdownItem
              key={lang}
              onClick={() => contentControls.setLang(lang)}
            >
              {lang}
            </DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>
      <Dropdown isOpen={companyDropdownOpen} toggle={toggleCopmany}>
        <DropdownToggle caret>{contentControls.currentCompany}</DropdownToggle>
        <DropdownMenu>
          {companies?.map(company => (
            <DropdownItem
              key={company}
              onClick={() => contentControls.setCompany(company)}
            >
              {company}
            </DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>
      {user && (
        <div>
          <span>{user.name}</span>
          <Button color="primary" onClick={logout}>
            {labels.logoutButton}
          </Button>
        </div>
      )}
    </UserMenuContainer>
  );
};
const UserMenuContainer = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-flow: column wrap;
  button {
    font-size: 10px;
  }

  div {
    margin-bottom: 10px;
  }
`;
export default UserMenu;
