import axios from 'axios';
import { showCustomPrompt } from './utils/promptHelper';

axios.defaults.baseURL = 'https://localhost:7282';

axios.interceptors.request.use(
  config => {
    const bbCode = localStorage.getItem('bbCode');
    if (bbCode) {
      config.headers['X-BB-Code'] = bbCode;
    }else{
      showCustomPrompt(`Please enter a bbCode:`);
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(
  response => response,
  error => {
    const errorMessage = JSON.stringify(error);
    
    if (error.response && error.response.status === 418) {
      showCustomPrompt(`Error: ${error.response.status} - ${error.response.data.message}\nPlease enter a new bbCode:`);
    }
    return Promise.reject(error);
  }
);

export default axios;