export interface ParkingSpace {
    id: number
    lat : number
    lng : number
    parkingTypeId : number
    rateId : number
    rate: any
    parkingType: any
    // public ParkingType ParkingType;
    // public Rate Rate;
    // public ICollection<Parked> Parked
}