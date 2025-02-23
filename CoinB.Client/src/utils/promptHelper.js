import { useState } from 'react';

let setPromptMessage;
let setShowPrompt;

export const useCustomPrompt = () => {
  const [promptMessage, _setPromptMessage] = useState('');
  const [showPrompt, _setShowPrompt] = useState(false);

  setPromptMessage = _setPromptMessage;
  setShowPrompt = _setShowPrompt;

  return { promptMessage, showPrompt };
};

export const showCustomPrompt = (message) => {
  setPromptMessage(message);
  setShowPrompt(true);
};