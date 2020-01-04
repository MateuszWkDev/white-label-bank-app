import axios from 'axios';
import { DefaultTheme } from 'styled-components';
import { Labels } from '../contexts/LabelsContext';
import { Content } from '../contexts/ContentContext';

const serverUrl = 'http://localhost:50312';
const getUrl = (contentType: string, version: string) =>
  `${serverUrl}/content/${contentType}/${version}`;
class ContentService {
  static GetContent() {
    const version = new Date().getTime();
    return Promise.all([
      axios.get<Content>(getUrl('main', version.toString())),
      axios.get<Labels>(getUrl('labels', version.toString())),
      axios.get<DefaultTheme>(getUrl('theme', version.toString())),
    ]);
  }
}

export default ContentService;
