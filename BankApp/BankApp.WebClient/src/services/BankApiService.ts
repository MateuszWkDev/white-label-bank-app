import HttpClientService from './HttpClientService';
import { User } from '../contexts/UserContext';

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
}

export default BankApiService;
