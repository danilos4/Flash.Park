import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {  throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Location} from '../Model/location';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class FloorService extends BaseService {
  baseUrl: string = environment.BASE_URL;
 /*  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  }; */

  constructor (private http: HttpClient){
    super();
  }

  addCar(floorId: number ){
    return this.http.post(this.baseUrl + 'api/slot/addCar?floorId=' + floorId, null)//, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    );
  }

  removeCar(floorId: number ){
    return this.http.post(this.baseUrl + 'api/slot/removeCar?floorId=' + floorId, null)//, this.httpOptions)
    .pipe(
      catchError(this.handleError)
    );
  }
}
