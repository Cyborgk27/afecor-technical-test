import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        pathMatch: 'full',
        path: '',
        redirectTo: 'order-maintenance'
    },
    {
        path: 'order-maintenance',
        loadChildren: () => import('./modules/order-maintenance/order-maintenance-module')
            .then(m => m.OrderMaintenanceModule)
    }
];
