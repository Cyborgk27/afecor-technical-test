import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IOrder } from '../../../../shared/interfaces/order.interface';
import { OrderService } from '../../../../shared/services/order.service';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.html',
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatSortModule,
  ],
  styleUrls: ['./list-order.css']
})
export class ListOrder implements OnInit {

  displayedColumns: string[] = ['id', 'clientId', 'orderDate', 'total', 'acciones'];
  dataSource = new MatTableDataSource<IOrder>([]);

  constructor(
    private orderService: OrderService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getAllOrders().subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.dataSource.data = res.data ?? [];
        }
      },
      error: (err) => console.error('Error cargando pedidos', err)
    });
  }

  // Navegar a crear nuevo pedido
  createOrder() {
    this.router.navigate(['order-maintenance/create-order']);
  }

  // Navegar a editar pedido existente
  editOrder(order: IOrder) {
    this.router.navigate(['order-maintenance/update-order/', order.id]);
  }

  // deleteOrder(order: IOrder) {
  //   console.log('Eliminar pedido', order);
  //   // ⚡ Aquí luego harías la llamada al backend
  // }

  deleteOrder(order: IOrder) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: `Eliminar pedido #${order.id} no se puede deshacer.`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        // Llamada al backend para eliminar
        this.orderService.deleteOrder(order.id).subscribe({
          next: () => {
            Swal.fire('Eliminado', `Pedido #${order.id} eliminado`, 'success');
            this.loadOrders(); // recargar lista
          },
          error: () => Swal.fire('Error', 'No se pudo eliminar el pedido', 'error')
        });
      }
    });
  }
}
