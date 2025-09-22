import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { OrderService } from '../../../../shared/services/order.service';
import { IOrderDetail } from '../../../../shared/interfaces/order-detail.interface';
import { IOrder } from '../../../../shared/interfaces/order.interface';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { ClientService } from '../../../../shared/services/client.service';
import { ProductService } from '../../../../shared/services/product.service';
import { IClient } from '../../../../shared/interfaces/client.interface';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { IProduct } from '../../../../shared/interfaces/product.interface';
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-form-order',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  templateUrl: './form-order.html',
  styleUrl: './form-order.css'
})
export class FormOrder {
  orderForm!: FormGroup;
  clients!: IClient[]
  products!: IProduct[]
  orderId?: number;

  constructor(
    private fb: FormBuilder,
    private orderService: OrderService,
    private clientService: ClientService,
    private productService: ProductService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.orderForm = this.fb.group({
      id: [null],
      clientId: [null, Validators.required],
      orderDate: [new Date().toISOString().slice(0, 10), Validators.required],
      total: [0, Validators.required],
      details: this.fb.array([])
    });

    this.loadClients()
    this.loadProducts()

    // Verificar si hay id en ruta
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.orderId = +id;
        this.loadOrder(this.orderId);
      }
    });
  }

  // getter para acceder fácil al array
  get details(): FormArray {
    return this.orderForm.get('details') as FormArray;
  }

  detailGroup(index: number): FormGroup {
    return this.details.at(index) as FormGroup;
  }

  loadOrder(id: number) {
    this.orderService.getOrderById(id).subscribe({
      next: (res) => {
        // Cabecera
        this.orderForm.patchValue({
          clientId: res.data?.clientId,
          orderDate: res.data?.orderDate ? new Date(res.data.orderDate) : new Date(),
          total: res.data?.total
        });

        // Detalles
        res.data?.details?.forEach(d => {
          const detailForm = new FormGroup({
            productId: new FormControl(d.productId, Validators.required),
            price: new FormControl(d.price, Validators.required),
            cost: new FormControl(d.cost, Validators.required),
            quantity: new FormControl(d.quantity, Validators.required),
            subTotal: new FormControl({ value: d.subTotal, disabled: true }),
            profitability: new FormControl({ value: d.profitability, disabled: true })
          });
          this.details.push(detailForm);
        });
      },
      error: (err) => console.error(err)
    });
  }

  // Añadir nuevas propiedades
  globalProfitability: number = 0;
  profitabilityColor: string = 'text-gray-700';

  // Crear detalle con costo y rentabilidad
  newDetail(detail?: IOrderDetail): FormGroup {
    return this.fb.group({
      id: [detail?.id || null],
      orderId: [detail?.orderId || 0],
      productId: [detail?.productId || null, Validators.required],
      price: [detail?.price || 0, Validators.required],
      cost: [detail?.cost || 0, Validators.required], // nuevo campo
      quantity: [detail?.quantity || 1, Validators.required],
      subTotal: [{ value: detail?.subTotal || 0, disabled: true }],
      profitability: [{ value: detail?.profitability || 0, disabled: true }]
    });
  }

  calculateDetail(detailForm: FormGroup): void {
    const price = detailForm.get('price')?.value || 0;
    const cost = detailForm.get('cost')?.value || 0;
    const qty = detailForm.get('quantity')?.value || 0;

    const subtotal = price * qty;
    detailForm.get('subTotal')?.setValue(subtotal, { emitEvent: false });

    const profitability = price > 0 ? ((price - cost) / price) * 100 : 0;
    detailForm.get('profitability')?.setValue(profitability, { emitEvent: false });

    this.calculateTotalAndGlobalProfit();
  }

  // Calcular total y rentabilidad global
  calculateTotalAndGlobalProfit(): void {
    let total = 0;
    let totalProfitPerc = 0;
    const count = this.details.length;

    this.details.controls.forEach(c => {
      total += c.get('subTotal')?.value || 0;
      totalProfitPerc += c.get('profitability')?.value || 0;
    });

    this.orderForm.get('total')?.setValue(total);

    this.globalProfitability = count > 0 ? totalProfitPerc / count : 0;

    // Color según rentabilidad global
    if (this.globalProfitability < 20) this.profitabilityColor = 'text-red-500';
    else if (this.globalProfitability <= 35) this.profitabilityColor = 'text-yellow-500';
    else this.profitabilityColor = 'text-green-500';
  }

  loadProducts() {
    this.productService.getAvailableProducts().subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.products = res.data ?? [];
        }
      },
      error: (err) => console.error(err)
    });
  }

  loadClients() {
    this.clientService.getAvailableClients().subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.clients = res.data ?? [];
        }
      },
      error: (err) => console.error(err)
    });
  }


  addDetail(detail?: IOrderDetail): void {
    this.details.push(this.newDetail(detail));
  }

  removeDetail(index: number): void {
    this.details.removeAt(index);
    this.calculateTotal();
  }

  // recalcula subtotal y total
  calculateSubtotal(detailForm: FormGroup): void {
    const price = detailForm.get('price')?.value || 0;
    const qty = detailForm.get('quantity')?.value || 0;
    const subtotal = price * qty;
    detailForm.get('subTotal')?.setValue(subtotal, { emitEvent: false });
    this.calculateTotal();
  }

  calculateTotal(): void {
    const total = this.details.controls.reduce((acc, curr) => {
      return acc + (curr.get('subTotal')?.value || 0);
    }, 0);
    this.orderForm.get('total')?.setValue(total);
  }

  confirmSubmit(): void {
    if (this.orderForm.invalid) return;

    Swal.fire({
      title: '¿Confirmar cambios?',
      text: this.orderId ? 'Se actualizará el pedido existente' : 'Se creará un nuevo pedido',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Sí, confirmar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.onSubmit();
      }
    });
  }


  onSubmit(): void {
    if (this.orderForm.invalid) return;

    const order: IOrder = {
      ...this.orderForm.getRawValue(), // getRawValue porque subTotal está disabled
    };

    if (this.orderId !== undefined) {
      order.id = this.orderId;
    }

    if (order.id) {
      // Editar
      this.orderService.updateOrder(order.id, order).subscribe({
        next: () => {
          Swal.fire({
            icon: 'success',
            title: 'Pedido actualizado',
            text: `El pedido #${order.id} se ha actualizado correctamente`,
            timer: 2000,
            showConfirmButton: false
          });
        },
        error: err => {
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'No se pudo actualizar el pedido'
          });
          console.error(err);
        }
      });
    } else {
      // Crear
      this.orderService.createOrder(order).subscribe({
        next: (res) => {
          Swal.fire({
            icon: 'success',
            title: 'Pedido creado',
            text: `El pedido #${res.data?.id || ''} se ha creado correctamente`,
            timer: 2000,
            showConfirmButton: false
          });
          this.orderForm.reset();
          this.details.clear(); // limpiar detalles si deseas
        },
        error: err => {
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'No se pudo crear el pedido'
          });
          console.error(err);
        }
      });
    }
  }
  onProductSelected(productId: number, detail: FormGroup) {
    const product = this.products.find(p => p.id === productId);
    if (product) {
      detail.get('price')?.setValue(product.price);
      this.calculateSubtotal(detail);
    }
  }
}
