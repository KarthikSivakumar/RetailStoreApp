import { Component,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { api_base_url } from '../AppConstants';
import { Products } from '../models/products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {
  public products: Products[] = [];
  private readonly _http:HttpClient
  //dtOptions:  DataTables.Settings = {};
  constructor(http: HttpClient) {
    this._http=http;
  }
  ngOnInit(): void {
    this._http.get<Products[]>(api_base_url + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}


