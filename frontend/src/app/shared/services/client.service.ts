import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { IBaseResponse } from '../interfaces/common/base-response.interface';
import { IClient } from '../interfaces/client.interface';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  
  constructor(private http: HttpClient) {}

  getAvailableClients(): Observable<IBaseResponse<IClient[]>> {
    return this.http.get<IBaseResponse<IClient[]>>(`${environment.urlAddress}available`);
  }
}
