import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { api_base_url } from '../AppConstants';
import { Products } from '../models/products';
import { CsvHelperService } from '../../services/csvhelper/csvhelper.service';
import { ValidatorConfig } from 'csv-file-validator';
import { ModalService } from '../../services/modal/modal.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Products[] = [];
  private readonly _http: HttpClient;
  private readonly csvService: CsvHelperService;
  private csvConfig: ValidatorConfig;
  productForm:FormGroup = new FormGroup({
    Sku: new FormControl('',Validators.required),
    ProductName: new FormControl('',Validators.required),
    StoreName: new FormControl(0,Validators.required),
    Price: new FormControl(0,Validators.required),
    EffectiveDate: new FormControl(0,Validators.required)
  });
  constructor(http: HttpClient, CsvService: CsvHelperService, protected modalService: ModalService) {
    this._http = http;
    this.csvService = CsvService;
    this.csvConfig = { headers: [] };
  }
  ngOnInit(): void {
    this._http.get<Products[]>(api_base_url + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
  handleCSVUpload(csvFile: File) {
    this.csvConfig = {
      headers: [],

    };
    this.csvService.validateCSVFile(csvFile, this.csvConfig)
      .then(() => {
        this.csvService.uploadCSVFile(csvFile);
      })
      .catch((e) => { console.log(e) });
  }
}


