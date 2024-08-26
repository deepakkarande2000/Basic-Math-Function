import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _httpClient: HttpClient) { }

  ServerURL: any = "https://localhost:4001/api/Calculate";

  public async CalculateValue(param1: any, param2: any, opCode: any): Promise<Observable<any>> {
    let params = new HttpParams()
      .set('i', param1)
      .set('j', param2) // Convert number to string
      .set('opcode', opCode.toString()); // Convert boolean to string
   return await this._httpClient.get<any>(this.ServerURL, { params });    
  }
}
