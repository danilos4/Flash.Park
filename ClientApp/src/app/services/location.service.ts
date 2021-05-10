import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse  } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {  throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Location} from '../Model/location';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService extends BaseService {
  baseUrl: string = environment.BASE_URL;

  constructor (private http: HttpClient)
  {
    super();
  }

  getAllLocations(){
    return this.http.get<Location[]>(this.baseUrl + 'api/location/getAllLocations')
    .pipe(
      catchError(this.handleError)
    );
  }

  addCar(locationId: number, floorId: number ){
    return this.http.post(this.baseUrl + 'api/floor/addCar', {"locationId": locationId, "floorId": floorId})
    .pipe(
      catchError(this.handleError)
    );
  }
}
