export class Products {
    sku: string;
    storeID: number;
    storeName: string;
    productName: string;
    effectiveStartDate: Date;
    price: number;

    /**
     *
     */
    constructor() {
        this.sku="";
        this.productName="";
        this.storeID=0;
        this.storeName = "";
        this.effectiveStartDate=new Date();
        this.price=0;
    }
  }