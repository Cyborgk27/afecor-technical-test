import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IOrder } from '../../../../shared/interfaces/order.interface';
import { OrderService } from '../../../../shared/services/order.service';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

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

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getAllIOrders().subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.dataSource.data = res.data ?? [];
        }
      },
      error: (err) => console.error('Error cargando pedidos', err)
    });
  }

  editOrder(order: IOrder) {
    console.log('Editar pedido', order);
    // ⚡ Aquí luego abrirías un dialog o navegarías a otra ruta
  }

  deleteOrder(order: IOrder) {
    console.log('Eliminar pedido', order);
    // ⚡ Aquí luego harías la llamada al backend
  }
}
