import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../entities/Client';

@Injectable()
export class ClientService {

  legalPersonUrl: string = 'http://localhost:5000/LegalPerson';

  constructor(private http: HttpClient) { }
  getClients() : Observable<Client[]> {
    return this.http.get<Client[]>(`${this.legalPersonUrl}`);
  }

  getClientById(id: number) : Observable<Client> {
    return this.http.get<Client>(`${this.legalPersonUrl}/${id}`);
  }

  public post(client: Client): Observable<Client> {
    return this.http
      .post<Client>(this.legalPersonUrl, client);
  }

  public put(client: Client): Observable<Client> {
    return this.http
      .put<Client>(`${this.legalPersonUrl}/${client.id}`, client);
  }

  public deleteClient(id: number): Observable<any> {
    return this.http
      .delete(`${this.legalPersonUrl}/${id}`);
  }
}
