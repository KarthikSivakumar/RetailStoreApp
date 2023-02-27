import { Injectable } from '@angular/core';
import CSVFileValidator, { ValidatorConfig } from 'csv-file-validator';

@Injectable({
  providedIn: 'root'
})
export class CsvHelperService {

  constructor() { }
  validateCSVFile(csvFile:File,config:ValidatorConfig){
    return CSVFileValidator(csvFile, config);
  }
  uploadCSVFile(csvFile:File){

  }
}
