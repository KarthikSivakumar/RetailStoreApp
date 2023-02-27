import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { api_base_url } from '../AppConstants';
import { Stores } from '../models/stores';
import { ModalService } from '../../services/modal/modal.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-Stores',
  templateUrl: './Stores.component.html'
})
export class StoresComponent implements OnInit {
  public Stores: Stores[] = [];
  private readonly _http: HttpClient;
  productForm:FormGroup = new FormGroup({
    Sku: new FormControl('',Validators.required),
    ProductName: new FormControl('',Validators.required),
    StoreName: new FormControl(0,Validators.required),
    Price: new FormControl(0,Validators.required),
    EffectiveDate: new FormControl(0,Validators.required)
  });
  constructor(http: HttpClient, protected modalService: ModalService) {
    this._http = http;
  }
  ngOnInit(): void {
    this._http.get<Stores[]>(api_base_url + 'store').subscribe(result => {
      this.Stores = result;
    }, error => console.error(error));
  }
}


