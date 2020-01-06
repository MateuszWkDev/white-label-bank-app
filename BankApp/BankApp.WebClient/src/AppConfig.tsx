const isOnTest = window.location.href.includes('test-wlba');
class AppConfig {
  static defaultLang = 'en';

  static defaultCompany = 'default';

  static contentServerUrl = isOnTest
    ? 'https://contentapi-test-wlba.azurewebsites.net'
    : 'http://localhost:50312';

  static bankApiUrl = isOnTest
    ? 'https://bankapi-test-wlba.azurewebsites.net/api'
    : 'http://localhost:61493/api';

  static baseMediaUrl = isOnTest
    ? 'https://contentapi-test-wlba.azurewebsites.net/media'
    : 'http://localhost:50312/media';
}
export default AppConfig;
