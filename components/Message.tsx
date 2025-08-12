import React from 'react';
import { type Message as MessageType } from '../types';
import { BotIcon } from './icons';

interface MessageProps {
  message: MessageType;
}

const Message: React.FC<MessageProps> = ({ message }) => {
  const isBot = message.sender === 'bot';

  const botMessageClasses = "flex items-start space-x-3";
  const userMessageClasses = "flex items-end justify-end space-x-3";

  const botBubbleClasses = "bg-white text-gray-800 p-3 rounded-lg rounded-tl-none shadow-md max-w-lg";
  const userBubbleClasses = "bg-green-600 text-white p-3 rounded-lg rounded-br-none shadow-md max-w-lg";

  return (
    <div className={isBot ? botMessageClasses : userMessageClasses}>
      {isBot && (
        <div className="flex-shrink-0 bg-green-700 text-white rounded-full p-1">
            <BotIcon />
        </div>
      )}
      <div className={isBot ? botBubbleClasses : userBubbleClasses}>
        <p className="text-sm" style={{ whiteSpace: 'pre-wrap' }}>{message.text}</p>
      </div>
    </div>
  );
};

export default Message;
