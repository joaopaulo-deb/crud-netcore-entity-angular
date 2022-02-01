import { Client } from "./Client";

export interface Telephone {
  id: number;
  number: string;
  clientId: string;
  client: Client;
}
