import axios from './axiosConfig';

export const getAllAccounts = async () => {
  try {
    const response = await axios.get('/accounts');
    return response.data;
  } catch (error) {    
    console.error('Error fetching accounts:', error);
    throw error;
  }
};