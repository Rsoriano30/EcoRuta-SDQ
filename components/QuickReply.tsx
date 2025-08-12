import React from 'react';
import { MapPinIcon, CalendarIcon, WarningIcon, RecycleIcon, QuestionMarkCircleIcon, PhoneIcon } from './icons';
import { QUICK_REPLY_TEXTS } from '../constants';

interface QuickReplyProps {
  onSelectReply: (reply: string) => void;
}

const QuickReply: React.FC<QuickReplyProps> = ({ onSelectReply }) => {
  const repliesWithIcons = QUICK_REPLY_TEXTS.map((text, index) => {
    const icons = [
        <MapPinIcon />, 
        <CalendarIcon />, 
        <WarningIcon />, 
        <RecycleIcon />, 
        <QuestionMarkCircleIcon />, 
        <PhoneIcon />
    ];
    return { text, icon: icons[index] };
  });

  return (
    <div className="px-4 pb-4 pt-2 flex flex-col gap-2">
      {repliesWithIcons.map((reply, index) => (
        <button
          key={index}
          onClick={() => onSelectReply(reply.text)}
          className="flex items-center text-left w-full bg-white text-green-800 font-medium py-3 px-4 border border-gray-200 rounded-lg hover:bg-green-50 focus:outline-none focus:ring-2 focus:ring-offset-1 focus:ring-green-500 transition-colors duration-200 shadow-sm"
        >
          <span className="font-bold text-gray-500 mr-3">{index + 1}.</span>
          {reply.icon}
          <span className="ml-1">{reply.text}</span>
        </button>
      ))}
    </div>
  );
};

export default QuickReply;