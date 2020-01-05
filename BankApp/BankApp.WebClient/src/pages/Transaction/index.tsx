import React, { useState, useEffect, useCallback, useContext } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useHistory } from 'react-router-dom';
import Account from '../../models/Account';
import BankApiService from '../../services/BankApiService';
import Routes from '../../routes/Routes';
import LabelsContext from '../../contexts/LabelsContext';

const getAccountIdByNumber = (accounts: Account[], accountNumber: string) =>
  accounts.find(
    account => account.number.toLowerCase() === accountNumber.toLowerCase(),
  )?.id || 0;
const TransactionPage: React.FC = () => {
  const labels = useContext(LabelsContext);
  const [transactionData, setTransactionData] = useState({
    fromAccountNumber: '',
    toAccountNumber: '',
    amount: 0,
  });
  const [accounts, setAccounts] = useState<Account[]>([]);
  useEffect(() => {
    BankApiService.getAccountsForUser().then(response =>
      setAccounts(response.data),
    );
  }, []);
  const history = useHistory();
  const submit = useCallback(
    (e: React.FormEvent) => {
      e.preventDefault();
      BankApiService.performTransaction({
        amount: Number(transactionData.amount),
        fromAccountId: getAccountIdByNumber(
          accounts,
          transactionData.fromAccountNumber,
        ),
        toAccountId: getAccountIdByNumber(
          accounts,
          transactionData.toAccountNumber,
        ),
      }).then(response => {
        if (response.status === 200) {
          history.push(Routes.dashboard);
        }
      });
    },
    [
      accounts,
      history,
      transactionData.amount,
      transactionData.fromAccountNumber,
      transactionData.toAccountNumber,
    ],
  );
  const change = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setTransactionData(previousData => ({ ...previousData, [name]: value }));
  }, []);
  return (
    <div>
      <h4>{labels.transactionHeader}</h4>
      <Form onSubmit={submit}>
        <FormGroup>
          <Label for="fromAccountNumber">{labels.fromAccountNumber}</Label>
          <Input
            name="fromAccountNumber"
            id="fromAccountNumber"
            value={transactionData.fromAccountNumber}
            onChange={change}
          />
        </FormGroup>
        <FormGroup>
          <Label for="toAccountNumber">{labels.toAccountNumber}</Label>
          <Input
            name="toAccountNumber"
            id="toAccountNumber"
            value={transactionData.toAccountNumber}
            onChange={change}
          />
        </FormGroup>
        <FormGroup>
          <Label for="amount">{labels.amount}</Label>
          <Input
            type="number"
            step=".01"
            name="amount"
            id="amount"
            value={transactionData.amount}
            onChange={change}
          />
        </FormGroup>
        <Button color="primary">{labels.submitButton}</Button>
      </Form>
    </div>
  );
};

export default TransactionPage;
