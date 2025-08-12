import { type RouteInfo, type ScheduleInfo } from './types';

export const ROUTES: RouteInfo[] = [
  { id: 'R1', name: 'Ruta Norte-1', sectors: ['Villa Progreso', 'Los Girasoles', 'Centro Histórico'], truck: 'C-101', driver: 'Juan Pérez' },
  { id: 'R2', name: 'Ruta Sur-A', sectors: ['Mirador Sur', 'Bella Vista', 'La Paz', 'Cristo Rey'], truck: 'C-205', driver: 'Ana Rodríguez' },
  { id: 'R3', name: 'Ruta Este-Central', sectors: ['Ensanche Ozama', 'Villa Duarte', 'Los Mina', 'Villa Juana', 'Ensanche Kennedy'], truck: 'C-302', driver: 'Carlos Gomez' },
];

export const SCHEDULES: ScheduleInfo[] = [
  {
    sector: 'Villa Progreso',
    days: [
      { day: 'Lunes', time: '8:00 AM - 10:00 AM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Miércoles', time: '8:00 AM - 10:00 AM', type: 'Inorgánica', status: 'A tiempo' },
      { day: 'Viernes', time: '9:00 AM - 11:00 AM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  },
    {
    sector: 'Villa Juana',
    days: [
      { day: 'Lunes', time: '7:00 AM - 10:00 AM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Miércoles', time: '7:00 AM - 10:00 AM', type: 'Inorgánica', status: 'A tiempo' },
      { day: 'Viernes', time: '7:00 AM - 10:00 AM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Sábado', time: '9:00 AM - 12:00 PM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  },
  {
    sector: 'Cristo Rey',
    days: [
      { day: 'Martes', time: '5:30 PM - 8:00 PM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Jueves', time: '5:30 PM - 8:00 PM', type: 'Inorgánica', status: 'A tiempo' },
      { day: 'Sábado', time: '9:00 AM - 12:00 PM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  },
  {
    sector: 'Los Girasoles',
    days: [
      { day: 'Lunes', time: '10:00 AM - 12:00 PM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Miércoles', time: '10:00 AM - 12:00 PM', type: 'Inorgánica', status: 'Retrasado' },
      { day: 'Viernes', time: '11:00 AM - 1:00 PM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  },
  {
    sector: 'Centro Histórico',
    days: [
      { day: 'Martes', time: '7:00 AM - 9:00 AM', type: 'Orgánica', status: 'A tiempo' },
      { day: 'Jueves', time: '7:00 AM - 9:00 AM', type: 'Inorgánica', status: 'A tiempo' },
      { day: 'Sábado', time: '8:00 AM - 10:00 AM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  },
  {
    sector: 'Mirador Sur',
    days: [
        { day: 'Martes', time: '9:00 AM - 11:00 AM', type: 'Orgánica', status: 'A tiempo' },
        { day: 'Jueves', time: '9:00 AM - 11:00 AM', type: 'Inorgánica', status: 'A tiempo' },
        { day: 'Sábado', time: '10:00 AM - 12:00 PM', type: 'Reciclaje', status: 'A tiempo' },
    ]
  }
];

export const FAQS = [
    {
        question: "¿Qué días pasa el camión en mi barrio?",
        answer: "Para saber los días de recolección, puedes usar la opción 1 o 2 del menú principal para consultar las rutas y calendarios por zona."
    },
    {
        question: "¿Qué tipo de basura no se recoge?",
        answer: "No recogemos escombros de construcción, electrodomésticos grandes, ni productos químicos o residuos peligrosos como jeringas. Para estos, debe contactar directamente al ayuntamiento."
    },
    {
        question: "¿Qué hacer si el camión no pasó?",
        answer: "Puedes reportar un fallo en el servicio directamente desde nuestro menú principal. Selecciona la opción 'Reportar un Problema' y sigue los pasos."
    },
    {
        question: "¿Dónde reportar acumulación de basura?",
        answer: "La opción 'Reportar un Problema' en el menú principal te permite informar sobre acumulación de basura. Solo selecciona la opción correspondiente."
    }
];

export const RECYCLING_TIPS = [
    "Separa tus residuos en tres contenedores: orgánico, inorgánico y reciclable. ¡Facilita el proceso y ayuda al planeta!",
    "Limpia los envases de plástico y vidrio antes de depositarlos en el contenedor de reciclaje para evitar malos olores y contaminación.",
    "El cartón debe estar plegado para ocupar menos espacio. Quita cualquier cinta adhesiva antes de reciclarlo.",
    "Las baterías y aparatos electrónicos pequeños deben llevarse a puntos de reciclaje específicos, no los tires en la basura común.",
    "Reduce el uso de plásticos de un solo uso. ¡Usa bolsas reutilizables y botellas de agua recargables!"
];

export const CONTACT_INFO = {
    department: "Departamento de Residuos Sólidos",
    address: "Av. 27 de Febrero #105",
    email: "residuos@ayuntamiento.gob.do",
    whatsapp: "+1 809-555-1234",
    hours: "Lunes a Viernes de 8:00 AM a 5:00 PM"
};

const ZONAL_INFO = {
    "Santo Domingo Este": "🕒 Santo Domingo Este (ASDE)\nLa alcaldía indica que en el municipio la recolección cubre las circunscripciones 1, 2 y 3, con cobertura del 100 % en todos los sectores urbanos.\n\nEn general, el servicio se realiza:\n- Lunes, miércoles y viernes\n- En los barrios comunes\n- En horario diurno, desde 6:00 a.m. hasta 4:00 p.m. aproximadamente (Fuente: El Nuevo Diario).\n\nEn avenidas y comercios principales (San Vicente de Paúl, Charles de Gaulle, etc.), el servicio ocurre cada noche a las 7:00 p.m.",
    "Distrito Nacional": "🏙️ Distrito Nacional (ADN)\nEl Ayuntamiento tiene un plan de rutas y frecuencias actualizado al 2024, consultable en su portal de transparencia.\n\nEn sectores piloto (Piantini, Paraiso), se recoge no orgánico todos los miércoles de 8:00 a.m. a 12:00 m., y los orgánicos se recogen en sus días habituales.\n\nEn zonas residenciales comunes la recolección suele ser lunes, miércoles y viernes de día. En algunos barrios del centro, la recolección puede ser nocturna según ruta.",
    "Santo Domingo Norte": "🚛 Santo Domingo Norte\nSegún informes municipales, la alcaldía duplicó capacidad operativa y usa moto-basuras para zonas de difícil acceso.\n\nLas moto-basuras operan en dos turnos:\n- 5:00 a.m. a 3:00 p.m.\n- 4:00 p.m. a 11:00 p.m. para rutas en barrios estrechos.\n\nSe recomienda a ciudadanos esperar a sacar la basura justo en el horario del turno correspondiente.",
    "Santo Domingo Oeste": "🌆 Santo Domingo Oeste\nEl portal municipal indica que el horario administrativo es de lunes a viernes de 8:00 a.m. a 3:00 p.m., aunque el operativo, como la recolección, se realiza en horarios extendidos según ruta, aunque no explicitados en el sitio ayuntamientosdo.gob.do."
};

export const ZONAL_SCHEDULE_INFO = {
    "Santo Domingo Este": "🕒 **Santo Domingo Este (ASDE)**\n\n- **Frecuencia:** Lunes, miércoles y viernes.\n- **Horario general:** 6:00 a.m. a 4:00 p.m. en la mayoría de sectores.\n- **Sectores específicos (turnos nocturnos):** En barrios como El Invi, Prados del Cachón I-II, Los Mina, San Antonio, etc., se están probando dos turnos:\n  - 4:00 p.m. – 10:00 p.m.\n  - Algunos sectores tienen rutas de 9:00 p.m. – 3:00 a.m.",
    "Distrito Nacional": "🏙️ **Distrito Nacional (ADN)**\n\n- **Servicio general:** Lunes a viernes, con horario operativo típico de 8:00 a.m. – 5:00 p.m.\n- **Detalles por sector piloto (como Piantini o Paraiso):** La recolección de residuos inorgánicos es los miércoles de 8:00 a.m. a 12:00 m.",
    "Santo Domingo Norte": "🚛 **Santo Domingo Norte (SDN)**\n\nEn los portales del municipio no hay horarios operativos detallados publicados. Se menciona la prestación del servicio institucional sin especificar horas concretas.",
    "Santo Domingo Oeste": "🌆 **Santo Domingo Oeste**\n\n- **Servicio administrativo:** Lunes a viernes de 8:00 a.m. a 3:00 p.m.\n- **Servicio operativo:** El servicio de recolección funciona las 24 horas, adaptándose a diferentes rutas y turnos fuera del horario administrativo."
};

export const QUICK_REPLY_TEXTS = [
  'Rutas de Recolecciones',
  'Consultar Calendarios de Recogida',
  'Reportar un Problema',
  'Tips de Reciclaje',
  'Preguntas Frecuentes',
  'Contactar con el Ayuntamiento',
];

export const MAIN_MENU_TEXT = `\n¿En qué más puedo ayudarte? Aquí tienes las opciones principales:\n${QUICK_REPLY_TEXTS.map((text, index) => `${index + 1}️⃣  ${text}`).join('\n')}`;


export const SYSTEM_INSTRUCTION = `
You are EcoBot, a friendly and helpful virtual assistant for EcoRutaRD, a waste management service. Your purpose is to assist citizens. Your personality should be helpful, empathetic, and professional. You MUST respond ONLY in Spanish.

You have access to the following data. Use this information exclusively to answer user questions. Do not invent information.

**Data:**
- Routes: ${JSON.stringify(ROUTES)}
- Schedules: ${JSON.stringify(SCHEDULES)}
- Zonal Info: ${JSON.stringify(ZONAL_INFO)}
- Zonal Schedule Info: ${JSON.stringify(ZONAL_SCHEDULE_INFO)}
- FAQs: ${JSON.stringify(FAQS)}
- Recycling Tips: ${JSON.stringify(RECYCLING_TIPS)}
- Contact Info: ${JSON.stringify(CONTACT_INFO)}

**Conversation Flow:**

1.  **Greeting:** The user will be greeted and shown the main menu in the first message. Your role is to respond to their selection and subsequent queries.

2.  **Handling User Input:** The user can type the full text or the corresponding number for a menu option. You must be able to handle both inputs.

3.  **Presenting the Main Menu:**
    - After providing a complete answer for any of the main flows, or when a user chooses to go back to the menu from a sub-menu, you MUST end your response by presenting the main menu again.
    - To do this, after your main answer (e.g., providing a schedule, confirming a report), you MUST append the following text exactly: "${MAIN_MENU_TEXT}"

**Main Menu Flows (Examples):**

*   **1. Rutas de Recolecciones:**
    - When the user selects this, FIRST present this sub-menu:
      "Claro, por favor, indícame en cuál de estas zonas te encuentras para darte la información correcta:\\n1️⃣ Santo Domingo Este\\n2️⃣ Distrito Nacional\\n3️⃣ Santo Domingo Norte\\n4️⃣ Santo Domingo Oeste\\n5️⃣ Volver al menú principal"
    - When the user selects a zone (by name or number), retrieve the corresponding information from the \`Zonal Info\` data and display it. The zone names are "Santo Domingo Este", "Distrito Nacional", "Santo Domingo Norte", and "Santo Domingo Oeste".
    - After providing the information, you MUST present the main menu.

*   **2. Consultar Calendarios de Recogida:**
    - When the user selects this, FIRST present this sub-menu:
      "Claro, por favor, indícame en cuál de estas zonas te encuentras para darte la información sobre los calendarios:\\n1️⃣ Santo Domingo Este\\n2️⃣ Distrito Nacional\\n3️⃣ Santo Domingo Norte\\n4️⃣ Santo Domingo Oeste\\n5️⃣ Volver al menú principal"
    - When the user selects a zone (by name or number), retrieve the corresponding information from the \`Zonal Schedule Info\` data and display it.
    - After providing the information, you MUST present the main menu.

*   **3. Reportar un Problema:**
    - When the user selects this, FIRST present this sub-menu:
      "🚨 ¿Qué tipo de problema deseas reportar?\\n1️⃣ El camión no pasó\\n2️⃣ Basura acumulada\\n3️⃣ Contenedor lleno o roto\\n4️⃣ Otro\\n5️⃣ Volver al menú principal"
    - After they choose a problem type, you MUST ask for their municipality: "Entendido. Para continuar, por favor, indícame tu municipio (por ejemplo: Santo Domingo Este, Distrito Nacional, etc.)."
    - After they provide the municipality, you MUST ask for their neighborhood: "Perfecto. Ahora, por favor, dime tu sector o barrio."
    - After they provide the neighborhood, you MUST ask for a written description of the problem: "Gracias. Por último, por favor, describe brevemente tu caso para tener todos los detalles (por ejemplo: 'Hay un cúmulo de basura en la esquina de la calle X con la Y desde hace 3 días')."
    - Once they provide the description, confirm the report with a unique ticket number. Respond with: "✅ ¡Gracias! Tu reporte ha sido registrado con el código #${'EK-' + Math.floor(1000 + Math.random() * 9000)}. Hemos guardado todos los detalles y lo atenderemos lo antes posible." Then, present the main menu.

*   **4. Tips de Reciclaje:**
    - When the user selects this, provide one random, helpful tip from the \`RECYCLING_TIPS\` list.
    - After giving the tip, ask: "¿Deseas más consejos?". If they say no, present the main menu. If they say yes, give another tip and repeat the question.

*   **5. Preguntas Frecuentes:**
    - When the user selects this, present the list of questions from the \`FAQS\` data as a numbered list. Add a final option to return to the menu. Example: "📌 Preguntas frecuentes:\\n1️⃣ ...\\n5️⃣ Volver al menú principal"
    - When the user selects a number, provide the corresponding 'answer' and then present the main menu.

*   **6. Contactar con el Ayuntamiento:**
    - When the user selects this, provide all the contact information from the \`CONTACT_INFO\` data in a clear, formatted way, and then present the main menu.

*   **Returning from a Sub-menu:**
    - If the user selects 'Volver al menú principal' from any sub-menu, respond with a confirmation like "Claro, aquí tienes las opciones." and then present the main menu.

**General Rules:**
- ALWAYS end a completed conversation flow by presenting the main menu.
- Do NOT present the main menu when you are in the middle of a flow asking for more information (e.g., asking for a sector or description).
- Keep responses concise and easy to read. Use emojis to make the interaction friendlier.
`;