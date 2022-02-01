import { ClientService } from './../../services/client.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from 'src/app/entities/Client';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-client-new',
  templateUrl: './client-new.component.html',
  styleUrls: ['./client-new.component.scss']
})
export class ClientNewComponent implements OnInit {
  client = {} as Client;
  form: FormGroup;

  state = 'post';

  constructor(private activatedrouter: ActivatedRoute,
              private clientService: ClientService,
              private toastr: ToastrService,
              private fb: FormBuilder,
              private router: Router) {
   }

   ngOnInit(): void {
    this.validation();
    this.load();

  }

  public load() : void {

    const clientId = this.activatedrouter.snapshot.paramMap.get('id');

    if (clientId !== null) {

      this.state = 'put';

      this.clientService
        .getClientById(+clientId)
        .subscribe(
          (client: Client) : void => {


            /*if(client.name == undefined){
              client.name = client.fantasyName;
            }*/
            this.client = { ...client };
            this.form.patchValue(this.client);
            console.log(this.client);
            //this.carregarLotes();
          },
          (error: any) => {
            console.error(error);
          }
        );
    }
  }


  public validation() : void {
    this.form = new FormGroup({
      email: new FormControl('',
        [Validators.required,
         Validators.email] ),
      classification: new FormControl('', Validators.required),
      cep: new FormControl('',Validators.required),
      fantasyName: new FormControl('',
         [Validators.required,Validators. maxLength(100)]),
      cnpj: new FormControl('',Validators.required),
      name: new FormControl('',Validators.required),
      cpf: new FormControl('',Validators.required),
    });
  }

  public saveAlter(): void {
      if(this.state == 'post'){

        this.client = {...this.form.value}

        this.clientService.post(this.client).subscribe(
          (clientReturn: Client) => {
            console.log(clientReturn);
            this.toastr.success('Success', 'Success');
            this.router.navigate([`clientsnew/${clientReturn.id}`]);
          },
          (error: any) => {
            console.error(error);
            this.toastr.error('Error', 'Error');
          }
        );
      } else {
        this.client = {id: this.client.id , ...this.form.value}
        console.log('put' , this.client)
        this.clientService.put(this.client).subscribe(
          (clientReturn: Client) => {
            console.log(clientReturn);
            this.toastr.success('Success', 'Success');
            this.router.navigate([`clientsnew/${clientReturn.id}`]);
          },
          (error: any) => {
            console.error(error);
            this.toastr.error('Error', 'Error');
          }
        );

      }
  }

}
