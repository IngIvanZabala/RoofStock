import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StockDataModel } from '../Models/stockData.model';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { BaseResponseModel } from '../Models/baseResponse.model';
@Injectable({
  providedIn: 'root'
})
export class StockService {

  apiUrl = environment.urlService;

  constructor(private http: HttpClient) {
  }

  getStockData(): Observable<StockDataModel[]> {
    // Calling the API to get all the data from the API
    return this.http.get<StockDataModel[]>(this.apiUrl + '/Stock');
  }
  getStockDataById(id): Observable<StockDataModel> {
    // Calling the API to get the data from the IP, sending the id
    return this.http.get<StockDataModel>(this.apiUrl + '/Stock/' + id);
  }
  saveStockDataById(id): Observable<BaseResponseModel> {
    // Calling the API to create a new record
    return this.http.post<BaseResponseModel>(this.apiUrl + '/Stock/' + id, '');
  }
}
