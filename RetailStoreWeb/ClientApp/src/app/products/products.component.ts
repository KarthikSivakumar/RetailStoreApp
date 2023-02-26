import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { api_base_url } from '../AppConstants'
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent {
  public products: Products[] = [];

  constructor(http: HttpClient) {
    http.get<Products[]>(api_base_url + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Products {
  sku: string;
  productName: number;
  effectiveStartDate: Date;
  price: number;
}
