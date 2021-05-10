import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { LocationService } from '../services/location.service';
import { Location} from '../Model/location';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.Component';
import { interval } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit{
  locations: Location[];
  baseUrl: string = environment.BASE_URL;

  constructor(private locationService: LocationService, private dialog: MatDialog ) {
    locationService.getAllLocations().subscribe(result => {
      this.locations = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    interval(3000)
      .pipe(
        startWith(0),
        switchMap(() => this.locationService.getAllLocations())
      )
      .subscribe(result => this.locations = result);
  }

  addCar(locationForParking: Location){
    this.performAction(locationForParking, "Add");
  }

  removeCar(locationForParking: Location){
    this.performAction(locationForParking, "Remove");
  }

  performAction(locationForParking: Location, action: string){
    let dialogRef = this.dialog.open(DialogComponent, {
      height: '400px',
      width: '600px',
    });
    dialogRef.componentInstance.parkingLocation = locationForParking;
    dialogRef.componentInstance.actionToPerform = action;
    dialogRef.afterClosed()
    .subscribe(data => {
      if(data){
        let capacity = this.locations.find(x => x.locationId == locationForParking.locationId)
            .floors.find(x=>x.floorId == data.data.id).capacity;
        this.locations.find(x => x.locationId == locationForParking.locationId)
            .floors.find(x=>x.floorId == data.data.id).availableSlots = capacity - data.data.results;

        this.locations = [...this.locations];
      }
    });
  }
}
