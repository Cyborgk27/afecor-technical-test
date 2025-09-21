import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListOrder } from './pages/list-order/list-order';
import { CreateOrder } from './pages/create-order/create-order';
import { UpdateOrder } from './pages/update-order/update-order';

const routes: Routes = [
  {
    pathMatch: 'full',
    path: '',
    redirectTo: 'list-order'
  },
  {
    path: 'list-order',
    component: ListOrder
  },
  {
    path: 'create-order',
    component: CreateOrder
  },
  {
    path: 'update-order',
    component: UpdateOrder
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderMaintenanceRoutingModule { }
