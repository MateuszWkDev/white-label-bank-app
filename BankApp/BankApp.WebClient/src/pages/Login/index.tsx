import React, { useContext, useState, useCallback } from 'react';
import { useHistory, useLocation } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Routes from '../../routes/Routes';
import UserContext from '../../contexts/UserContext';
import LabelsContext from '../../contexts/LabelsContext';
import BankApiService from '../../services/BankApiService';

const LoginPage: React.FC = () => {
  const labels = useContext(LabelsContext);
  const [userData, setUserData] = useState({
    login: '',
    password: '',
  });
  const history = useHistory();
  const location = useLocation();
  const { login } = useContext(UserContext);
  const { from } = location.state || { from: { pathname: Routes.home } };
  const submit = useCallback(
    (e: React.FormEvent) => {
      e.preventDefault();
      BankApiService.authenticate(userData.login, userData.password).then(
        response => {
          if (response.status === 200) {
            login(response.data, userData.password);
            history.replace(from);
          }
        },
      );
    },
    [login, userData, from, history],
  );
  const change = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUserData(previousData => ({ ...previousData, [name]: value }));
  }, []);
  return (
    <div>
      <p>{labels.loginPageInfo}</p>
      <Form onSubmit={submit}>
        <FormGroup>
          <Label for="login">{labels.login}</Label>
          <Input
            name="login"
            id="login"
            value={userData.login}
            onChange={change}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">{labels.password}</Label>
          <Input
            type="password"
            name="password"
            id="password"
            value={userData.password}
            onChange={change}
          />
        </FormGroup>
        <Button color="primary">{labels.submitButton}</Button>
      </Form>
    </div>
  );
};

export default LoginPage;
