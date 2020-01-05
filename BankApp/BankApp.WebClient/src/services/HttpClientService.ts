import axios from 'axios';

class HttpClientService {
  static baseInstance = axios.create();

  static authorizedInstance = axios.create();

  static configureBasicAuth(
    authData: { username: string; password: string } | undefined,
  ) {
    HttpClientService.authorizedInstance = axios.create({ auth: authData });
  }
}

export default HttpClientService;
