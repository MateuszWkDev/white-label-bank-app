import HttpClientService from './HttpClientService';
import { User } from '../contexts/UserContext';
import Account from '../models/Account';
import Transaction from '../models/Transaction';

const apiUrl = 'http://localhost:61493/api';
class BankApiService {
  static authenticate(username: string, password: string) {
    return HttpClientService.baseInstance.post<User>(
      `${apiUrl}/user/authenticate`,
      {
        username,
        password,
      },
    );
  }

  static getAccountsForUser() {
    return HttpClientService.authorizedInstance.get<Account[]>(
      `${apiUrl}/account/all-for-user`,
    );
  }

  static getTransactionsForUser() {
    return HttpClientService.authorizedInstance.get<Transaction[]>(
      `${apiUrl}/transaction/all-for-user`,
    );
  }

  static performTransaction(transaction: Transaction) {
    return HttpClientService.authorizedInstance.post(
      `${apiUrl}/transaction/perform`,
      transaction,
    );
  }
}

export default BankApiService;
