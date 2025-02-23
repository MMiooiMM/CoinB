import React, { useEffect, useState } from 'react';
import './App.css';
import MonthlyExpense from './components/MonthlyExpense';
import { getAllAccounts } from './api';
import CustomPrompt from './components/CustomPrompt';
import { useCustomPrompt } from './utils/promptHelper';

function App() {
  const [accounts, setAccounts] = useState([]);
  const { promptMessage, showPrompt } = useCustomPrompt();

  useEffect(() => {
    const fetchAccounts = async () => {
      try {
        const accountsData = await getAllAccounts();
        setAccounts(accountsData);
      } catch (error) {
        console.error('Error fetching accounts:', error);
      }
    };

    fetchAccounts();
  }, []);

  const handlePromptConfirm = (newBbCode) => {
    localStorage.setItem('bbCode', newBbCode);
    window.location.reload();
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Account Monthly Expense</h1>
        {accounts.map(account => (
          <MonthlyExpense key={account.accountId} accountId={account.accountId} />
        ))}
      </header>
      {showPrompt && (
        <CustomPrompt
          message={promptMessage}
          onConfirm={handlePromptConfirm}
        />
      )}
    </div>
  );
}

export default App;
