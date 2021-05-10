
import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Location } from '../Model/location';
import { UpdatedFloor } from '../Model/updatedFloor';
import { FloorService } from '../services/floor.service';

@Component({
  selector: 'app-dialog',
  templateUrl: 'dialog.component.html',
})
export class DialogComponent {
  public actionToPerform: string;
  public parkingLocation: Location;
  floorId: number;

  constructor(//@Inject(MAT_DIALOG_DATA) public parkingLocation: Location,
  //@Inject(MAT_DIALOG_DATA) public isForAddingCar: boolean,
    private dialogRef: MatDialogRef<DialogComponent>,
    private dialog: MatDialog,
    private floorService: FloorService) {
      console.log("parkingLocation",JSON.stringify(this.parkingLocation));
    }

  performAction(){
    if(this.floorId){
      this.doPerform().subscribe(results =>{
          if(results){
            let id = this.floorId;
            this.dialogRef.close({ data: { results, id }});
          }
        });
      }
  }

  doPerform(){
    return this.actionToPerform == 'Add' ? this.floorService.addCar(this.floorId) : this.floorService.removeCar(this.floorId);
  }

  changeClient(floorId: number){
    console.log("floorId: ", floorId);
    this.floorId = floorId;
  }

  cancel(){
    this.dialog.closeAll();
  }
}
