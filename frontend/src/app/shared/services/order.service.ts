import { Injectable } from '@angular/core';
import { IBaseResponse } from '../interfaces/common/base-response.interface';
import { IOrder } from '../interfaces/order.interface';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  
  constructor(private http: HttpClient) {}

  getAllOrders(): Observable<IBaseResponse<IOrder[]>> {
    return this.http.get<IBaseResponse<IOrder[]>>(`${environment.urlAddress}api/Order`);
  }

  getOrderById(id: number): Observable<IBaseResponse<IOrder>> {
    return this.http.get<IBaseResponse<IOrder>>(`${environment.urlAddress}api/Order/${id}`);
  }

  createOrder(IOrder: IOrder): Observable<IBaseResponse<IOrder>> {
    return this.http.post<IBaseResponse<IOrder>>(`${environment.urlAddress}api/Order`, IOrder);
  }

  updateOrder(id: number, IOrder: IOrder): Observable<IBaseResponse<IOrder>> {
    return this.http.put<IBaseResponse<IOrder>>(`${environment.urlAddress}api/Order/${id}`, IOrder);
  }

  deleteOrder(id: number): Observable<IBaseResponse<boolean>> {
    return this.http.delete<IBaseResponse<boolean>>(`${environment.urlAddress}api/Order/${id}`);
  }
}
