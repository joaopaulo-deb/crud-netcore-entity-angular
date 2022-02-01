import { Telephone } from "./Telephone";

export interface Client {
  id: number;
  email: string;
  classification: string;
  cep: string;
  telephones: Telephone[];
  fantasyName: string;
  cnpj: string;
  name: string;
  cpf: string;
}
