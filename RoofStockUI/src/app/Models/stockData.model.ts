export class StockDataModel {
    id: number;
    yearBuilt: string;
    listPrice: string;
    monthlyRent: string;
    grossYield: string;
    mainImageUrl: string;
    address1: string;
    address2: string;
    city: string;
    country: string;
    county: string;
    district: string;
    state: string;
    zipCode: string;
    zipPlusFour: string;
    bathRooms: string;
    bedRooms: string;
    squareFeet: string;
    resources: Resources;
}
export class Resources{
    photos: Photos[];
}
export class Photos{
    urlImage: string;
}
