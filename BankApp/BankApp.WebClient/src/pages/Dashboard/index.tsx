import React, { useState, useEffect, useContext } from 'react';
import { Table } from 'reactstrap';
import Account from '../../models/Account';
import Transaction from '../../models/Transaction';
import BankApiService from '../../services/BankApiService';
import LabelsContext from '../../contexts/LabelsContext';

const getAccountNameById = (accounts: Account[], id: number) =>
  accounts.find(account => account.id === id)?.name || 0;
const DashboardPage: React.FC = () => {
  const labels = useContext(LabelsContext);
  const [accounts, setAccounts] = useState<Account[]>([]);
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  useEffect(() => {
    BankApiService.getAccountsForUser().then(response =>
      setAccounts(response.data),
    );
    BankApiService.getTransactionsForUser().then(response =>
      setTransactions(response.data),
    );
  }, []);
  return (
    <div>
      <h4>{labels.dashboardHeader}</h4>
      <h5>{labels.accountsSubHeader}</h5>
      <Table>
        <thead>
          <tr>
            <th>{labels.accountName}</th>
            <th>{labels.accountNumber}</th>
            <th>{labels.accountBalance}</th>
          </tr>
        </thead>
        <tbody>
          {accounts.map(account => (
            <tr key={account.id}>
              <td>{account.name}</td>
              <td>{account.number}</td>
              <td>{account.balance}</td>
            </tr>
          ))}
        </tbody>
      </Table>
      <h5>{labels.transactionsSubHeader}</h5>
      <Table>
        <thead>
          <tr>
            <th>{labels.fromAccount}</th>
            <th>{labels.toAccount}</th>
            <th>{labels.amount}</th>
          </tr>
        </thead>
        <tbody>
          {transactions.map(transaction => (
            <tr key={transaction.id}>
              <td>{getAccountNameById(accounts, transaction.fromAccountId)}</td>
              <td>{getAccountNameById(accounts, transaction.toAccountId)}</td>
              <td>{transaction.amount}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default DashboardPage;
