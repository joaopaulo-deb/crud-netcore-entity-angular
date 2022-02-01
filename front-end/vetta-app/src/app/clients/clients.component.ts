import { ClientService } from './../services/client.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Client } from '../entities/Client';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnInit {

  public clients: Client[] = [];
  public clientsFiltered: Client[] = [];
  private _filter: string = '';

  public clientId: number = 0;


  modalRef?: BsModalRef;

  constructor(private clientService: ClientService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private router: Router) { }

  openModal(template: TemplateRef<any>, clientId: number) : void{
    this.clientId = clientId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.clientService
      .deleteClient(this.clientId)
      .subscribe(
        (result: any) => {
          console.log(result);
          if (result === 'Deleted') {
            this.toastr.success(
              'Deleted',
              'Deleted!'
            );
            this.GetLegalPersons();
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(
            `Error`,
            'Erro'
          );
          this.GetLegalPersons();
        }
      );
  }

  decline(): void {
    this.modalRef?.hide();

  }

  ngOnInit(): void {
    this.GetLegalPersons();
    //this.GetPhysicalPersons();
  }

  public get filter() : string {
    return this._filter;
  }

  public set filter(value: string) {
    this._filter = value;
    this.clientsFiltered = this.filter ? this.filterClients(this.filter) : this.clients;
  }

  filterClients(filter: string) : Client[] {
    filter = filter.toLocaleLowerCase();
    return this.clients.filter(
      (client : Client) => client.fantasyName.toLocaleLowerCase().indexOf(filter)!== -1 ||
                        client.email.toLocaleLowerCase().indexOf(filter)!== -1);
  }

  public GetLegalPersons(): void {
    this.clientService.getClients().subscribe(
      (response: Client[]) => {
                  console.log(response);
                  this.clientsFiltered = this.clients = response;
                },
      error => console.log(error)
    );
  }

  editClient(id: number): void {
    this.router.navigate([`clientnew/${id}`]);
  }
}
