export type Sender = 'user' | 'bot';

export interface Message {
  id: string;
  text: string;
  sender: Sender;
}

export interface RouteInfo {
  id: string;
  name: string;
  sectors: string[];
  truck: string;
  driver: string;
}

export interface ScheduleInfo {
  sector: string;
  days: {
    day: string;
    time: string;
    type: 'Orgánica' | 'Inorgánica' | 'Reciclaje';
    status: 'A tiempo' | 'Retrasado' | 'Cancelado';
  }[];
}
