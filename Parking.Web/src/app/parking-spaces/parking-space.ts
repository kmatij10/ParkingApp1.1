import { ParkingType } from '../parking-types/parking-type';

export interface ParkingSpace {
    id: number
    lat : number
    lng : number
    hours : number
    start : Date
    parkingTypeId : number
    rateId : number
    availabilityId : number
    availability: any
    rate: any
    parkingType: ParkingType
    // public ParkingType ParkingType;
    // public Rate Rate;
    // public ICollection<Parked> Parked
}