import { DefaultTheme } from 'styled-components';
import { Labels } from '../contexts/LabelsContext';
import { Content } from '../contexts/ContentContext';
import HttpClientService from './HttpClientService';

const serverUrl = 'http://localhost:50312';
const getUrl = (contentType: string, version: string) =>
  `${serverUrl}/content/${contentType}/${version}`;
class ContentService {
  static getContent() {
    const version = new Date().getTime();
    return Promise.all([
      HttpClientService.baseInstance.get<Content>(
        getUrl('main', version.toString()),
      ),
      HttpClientService.baseInstance.get<Labels>(
        getUrl('labels', version.toString()),
      ),
      HttpClientService.baseInstance.get<DefaultTheme>(
        getUrl('theme', version.toString()),
      ),
    ]);
  }
}

export default ContentService;
