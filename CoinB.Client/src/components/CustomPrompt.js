import React, { useState } from 'react';
import './CustomPrompt.css'; // 导入 CSS 文件

const CustomPrompt = ({ message, onConfirm }) => {
  const [inputValue, setInputValue] = useState('');

  const handleConfirm = () => {
    onConfirm(inputValue);
    setInputValue('');
  };

  return (
    <div className="custom-prompt-overlay">
      <div className="custom-prompt">
        <div className="custom-prompt-message">{message}</div>
        <input
          type="text"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
        />
        <button onClick={handleConfirm}>Confirm</button>
      </div>
    </div>
  );
};

export default CustomPrompt;