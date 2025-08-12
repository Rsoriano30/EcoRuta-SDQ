import React, { useState, useEffect } from 'react';
import { type Message } from './types';
import ChatWindow from './components/ChatWindow';
import ChatInput from './components/ChatInput';
import { getBotResponse } from './services/geminiService';
import { BotIcon } from './components/icons';
import { QUICK_REPLY_TEXTS } from './constants';

const App: React.FC = () => {
  const [messages, setMessages] = useState<Message[]>([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const menuText = QUICK_REPLY_TEXTS
      .map((text, index) => `${index + 1}️⃣  ${text}`)
      .join('\n');
    
    const initialBotMessage: Message = {
      id: 'init',
      text: `¡Hola! Soy EcoBot, tu asistente para mantener tu ciudad limpia 🌱\n\n¿En qué puedo ayudarte hoy?\n\n${menuText}`,
      sender: 'bot',
    };
    setMessages([initialBotMessage]);
  }, []);

  const handleSendMessage = async (text: string) => {
    if (!text.trim()) return;

    const userMessage: Message = {
      id: Date.now().toString(),
      text: text,
      sender: 'user',
    };

    setMessages(prev => [...prev, userMessage]);
    setIsLoading(true);

    try {
      const botResponseText = await getBotResponse(text);
      
      if (botResponseText) {
        const botMessage: Message = {
          id: (Date.now() + 1).toString(),
          text: botResponseText,
          sender: 'bot',
        };
        setMessages(prev => [...prev, botMessage]);
      }
    } catch (error) {
      const errorMessage: Message = {
        id: 'error-' + Date.now(),
        text: 'Lo siento, ha ocurrido un error. Por favor, intenta de nuevo.',
        sender: 'bot',
      };
      setMessages(prev => [...prev, errorMessage]);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="h-screen w-screen flex items-center justify-center bg-white font-sans">
      <div className="w-full max-w-2xl h-full sm:h-[90vh] sm:max-h-[700px] flex flex-col bg-gray-50 rounded-lg shadow-2xl overflow-hidden border border-gray-200">
        <header className="flex items-center justify-start p-4 bg-green-700 text-white shadow-md">
          <BotIcon/>
          <div className="ml-3">
            <h1 className="text-xl font-bold">EcoRutaRD Chatbot</h1>
            <p className="text-sm text-green-200">Tu asistente de recolección de basura</p>
          </div>
        </header>
        <ChatWindow messages={messages} isLoading={isLoading} />
        <ChatInput onSendMessage={handleSendMessage} isLoading={isLoading} />
      </div>
    </div>
  );
};

export default App;
