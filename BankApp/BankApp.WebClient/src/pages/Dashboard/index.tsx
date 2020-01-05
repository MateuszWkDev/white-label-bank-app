import React, { useState, useEffect } from 'react';
import { Table } from 'reactstrap';
import Account from '../../models/Account';
import Transaction from '../../models/Transaction';
import BankApiService from '../../services/BankApiService';

const getAccountNameById = (accounts: Account[], id: number) =>
  accounts.find(account => account.id === id)?.name || 0;
const DashboardPage: React.FC = () => {
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
      <h4>Dahsboard [HC]</h4>
      <h5>Accounts [HC]</h5>
      <Table>
        <thead>
          <tr>
            <th>Name [HC]</th>
            <th>Number [HC]</th>
            <th>Balance [HC]</th>
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
      <Table>
        <thead>
          <tr>
            <th>From Account [HC]</th>
            <th>To account [HC]</th>
            <th>Amount [HC]</th>
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
