import React, { useEffect, useState } from 'react';
import axios from '../axiosConfig';

const MonthlyExpense = ({ accountId }) => {
  const [totalExpense, setTotalExpense] = useState(0);

  useEffect(() => {
    const fetchMonthlyExpense = async () => {
      try {
        const response = await axios.get(`/account/${accountId}/transactions`, {
          params: {
            year: new Date().getFullYear(),
            month: new Date().getMonth() + 1,
          },
        });
        const transactions = response.data;
        const total = transactions.reduce((sum, transaction) => sum + transaction.amount, 0);
        setTotalExpense(total);
      } catch (error) {
        console.error('Error fetching monthly expense:', error);
      }
    };

    fetchMonthlyExpense();
  }, [accountId]);

  return (
    <div>
      <h3>Monthly Expense for Account {accountId}</h3>
      <p>Total Expense: ${totalExpense.toFixed(2)}</p>
    </div>
  );
};

export default MonthlyExpense;