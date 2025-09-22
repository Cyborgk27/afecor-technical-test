import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { IBaseResponse } from '../interfaces/common/base-response.interface';
import { IProduct } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  constructor(private http: HttpClient) {}
  
  getAvailableProducts(): Observable<IBaseResponse<IProduct[]>> {
    return this.http.get<IBaseResponse<IProduct[]>>(`${environment.urlAddress}api/product/available`);
  }
}
