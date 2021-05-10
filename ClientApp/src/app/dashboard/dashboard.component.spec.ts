import { async, ComponentFixture, fakeAsync, TestBed } from '@angular/core/testing';
import { Floor } from '../Model/floor';
import { Location } from '../Model/location';
import { DashboardComponent } from './dashboard.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { LocationService } from '../services/location.service';
import { of } from 'rxjs';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let locationServiceStub: Partial<LocationService>;
  let locations: Location[];

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        MatCardModule,
        MatButtonModule,
        HttpClientTestingModule,
        MatDialogModule
    ],
      declarations: [DashboardComponent],
      providers: [ { provide: LocationService, useValue: locationServiceStub } ],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should click addCar button', fakeAsync(() => {
    spyOn(component, 'addCar');

    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();

    fixture.whenStable().then(() => {
      expect(component.addCar).toHaveBeenCalled();
    });
  }));

  it('should click removeCar button', fakeAsync(() => {
    spyOn(component, 'removeCar');

    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();

    fixture.whenStable().then(() => {
      expect(component.removeCar).toHaveBeenCalled();
    });
  }));

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Flash Parking Dashboard');
  }));

  it('locations length should be 2', () => {
    locationServiceStub.getAllLocations().subscribe(result => {
       locations = result;
      });

    fixture.detectChanges();
    expect(locations.length).toBe(2);
  });

  locationServiceStub = {
    baseUrl: 'test.url.com',
    getAllLocations(){
      const loc1 = new LocationTest();
      loc1.city = "cityTest1";
      loc1.state = "cityState1";
      loc1.numberOfFloors = 2;
      loc1.totalAvailableSlots = 3;
      loc1.totalCapacity = 5;
      loc1.floors = [
          {availableSlots: 5, capacity: 6, floorNumber: 1, floorId: 1},
          {availableSlots: 5, capacity: 8, floorNumber: 2, floorId: 2}
        ];

      const loc2 = new LocationTest();
      loc2.city = "cityTest2";
      loc2.state = "cityState2";
      loc2.numberOfFloors = 3;
      loc2.totalAvailableSlots = 4;
      loc2.totalCapacity = 6;
      loc2.floors = [
          {availableSlots: 6, capacity: 7, floorNumber: 2, floorId: 2},
          {availableSlots: 6, capacity: 9, floorNumber:  3, floorId: 3}
        ];

      const results = [loc1, loc2];

      return of(results);
    }
  };

  class LocationTest implements Location{
    public locationId: number;
    public city: string;
    public state: string;
    public numberOfFloors: number;
    public totalAvailableSlots: number;
    public totalCapacity: number;
    public floors: Floor[];
  }


 /*  it('should start with count 0, then increments by 1 when clicked', async(() => {
    const countElement = fixture.nativeElement.querySelector('strong');
    expect(countElement.textContent).toEqual('0');

    const incrementButton = fixture.nativeElement.querySelector('button');
    incrementButton.click();
    fixture.detectChanges();
    expect(countElement.textContent).toEqual('1');
  })); */
});


