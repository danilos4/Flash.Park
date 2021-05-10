import { Floor } from "./floor";

export interface Location {
  locationId: number;
  city: string;
  state: string;
  numberOfFloors: number;
  totalAvailableSlots: number;
  totalCapacity: number;
  floors: Floor[];
}
