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

  private mockOrders: IOrder[] = [
    { id: 1, clientId: 101, orderDate: new Date().toISOString(), total: 250, state: 1 },
    { id: 2, clientId: 102, orderDate: new Date().toISOString(), total: 180, state: 1 },
    { id: 3, clientId: 103, orderDate: new Date().toISOString(), total: 320, state: 1 }
  ];

  getAllIOrders(): Observable<IBaseResponse<IOrder[]>> {
    return of({
      isSuccess: true,
      statusCodde: 200,
      message: 'Datos de prueba cargados',
      data: this.mockOrders ?? [],
      errors: []
    });
    
    // return this.http.get<IBaseResponse<IOrder[]>>(`${environment.urlAddress}`);
  }

  getIOrderById(id: number): Observable<IBaseResponse<IOrder>> {
    return this.http.get<IBaseResponse<IOrder>>(`${environment.urlAddress}${id}`);
  }

  createIOrder(IOrder: IOrder): Observable<IBaseResponse<IOrder>> {
    return this.http.post<IBaseResponse<IOrder>>(`${environment.urlAddress}`, IOrder);
  }

  updateIOrder(id: number, IOrder: IOrder): Observable<IBaseResponse<IOrder>> {
    return this.http.put<IBaseResponse<IOrder>>(`${environment.urlAddress}${id}`, IOrder);
  }

  deleteIOrder(id: number): Observable<IBaseResponse<boolean>> {
    return this.http.delete<IBaseResponse<boolean>>(`${environment.urlAddress}${id}`);
  }
}
