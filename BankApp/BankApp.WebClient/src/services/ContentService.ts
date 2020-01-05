import { DefaultTheme } from 'styled-components';
import Cookies from 'js-cookie';
import { Labels } from '../contexts/LabelsContext';
import { Content } from '../contexts/ContentContext';
import HttpClientService from './HttpClientService';
import AppConfig from '../AppConfig';

const contentVersionCookie = 'contentVersion';
const getUrl = (contentType: string, version: string) =>
  `${AppConfig.contentServerUrl}/content/${contentType}/${version}`;

class ContentService {
  static version =
    Cookies.get(contentVersionCookie) || new Date().getTime().toString();

  static getContent(lang: string, company: string) {
    const companyConfig = {
      params: {
        company,
      },
    };
    const langConfig = {
      params: {
        lang,
      },
    };
    ContentService.updateVersion();
    return Promise.all([
      HttpClientService.baseInstance.get<Content>(
        getUrl('main', ContentService.version),
        companyConfig,
      ),
      HttpClientService.baseInstance.get<Labels>(
        getUrl('labels', ContentService.version),
        langConfig,
      ),
      HttpClientService.baseInstance.get<DefaultTheme>(
        getUrl('theme', ContentService.version),
        companyConfig,
      ),
    ]);
  }

  static updateVersion() {
    HttpClientService.baseInstance
      .get<string>(`${AppConfig.contentServerUrl}/content/last-modified`)
      .then(({ data }) => {
        ContentService.version = data;
        Cookies.set(contentVersionCookie, data);
      });
  }
}
setInterval(ContentService.updateVersion, 30000);

export default ContentService;
