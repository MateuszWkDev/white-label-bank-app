import HttpClientService from './HttpClientService';
import { User } from '../contexts/UserContext';
import Account from '../models/Account';
import Transaction from '../models/Transaction';
import AppConfig from '../AppConfig';

class BankApiService {
  static authenticate(username: string, password: string) {
    return HttpClientService.baseInstance.post<User>(
      `${AppConfig.bankApiUrl}/user/authenticate`,
      {
        username,
        password,
      },
    );
  }

  static getAccountsForUser() {
    return HttpClientService.authorizedInstance.get<Account[]>(
      `${AppConfig.bankApiUrl}/account/all-for-user`,
    );
  }

  static getTransactionsForUser() {
    return HttpClientService.authorizedInstance.get<Transaction[]>(
      `${AppConfig.bankApiUrl}/transaction/all-for-user`,
    );
  }

  static performTransaction(transaction: Transaction) {
    return HttpClientService.authorizedInstance.post(
      `${AppConfig.bankApiUrl}/transaction/perform`,
      transaction,
    );
  }
}

export default BankApiService;
