import React, { useRef, useEffect } from 'react';
import { type Message as MessageType } from '../types';
import Message from './Message';
import { BotIcon } from './icons';

interface ChatWindowProps {
  messages: MessageType[];
  isLoading: boolean;
}

const ChatWindow: React.FC<ChatWindowProps> = ({ messages, isLoading }) => {
  const scrollRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (scrollRef.current) {
      scrollRef.current.scrollTop = scrollRef.current.scrollHeight;
    }
  }, [messages, isLoading]);

  return (
    <div ref={scrollRef} className="flex-1 p-6 space-y-6 overflow-y-auto">
      {messages.map((msg) => (
        <Message key={msg.id} message={msg} />
      ))}
      {isLoading && (
        <div className="flex items-start space-x-3">
          <div className="flex-shrink-0 bg-green-700 text-white rounded-full p-1">
            <BotIcon />
          </div>
          <div className="bg-white text-gray-800 p-3 rounded-lg rounded-tl-none shadow-md">
            <div className="flex items-center space-x-1">
                <span className="text-sm">EcoBot está escribiendo</span>
                <span className="w-2 h-2 bg-green-500 rounded-full animate-pulse delay-75"></span>
                <span className="w-2 h-2 bg-green-500 rounded-full animate-pulse delay-150"></span>
                <span className="w-2 h-2 bg-green-500 rounded-full animate-pulse delay-300"></span>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ChatWindow;
