import { ClientNewComponent } from './clients/client-new/client-new.component';
import { ClientsComponent } from './clients/clients.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'clients' , component: ClientsComponent},
  { path: 'clientnew' , component: ClientNewComponent },
  { path: 'clientnew/:id' , component: ClientNewComponent },
  { path: '' , redirectTo: 'clients', pathMatch: 'full' },
  { path: '**' , redirectTo: 'clients', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
