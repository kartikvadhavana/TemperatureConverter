import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import { pipe } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DataService } from 'src/services/data.service';

@Component({
  selector: 'app-temp-converter',
  templateUrl: './temp-converter.component.html',
  styleUrls: ['./temp-converter.component.scss']
})
export class TempConverterComponent implements OnInit {
  title = 'Temperature Converter';
  conversionForm: FormGroup;
  convertedValue = '';

  constructor(private formBuilder: FormBuilder, 
    private dataService: DataService) { }
  
  ngOnInit(): void {
    this.conversionForm = this.formBuilder.group({
      conversionUnit: [null],
      temperatureToConvert: [null]
    });
  }

  performConversion(){
    const params = new HttpParams()
    .set('conversionUnit',this.conversionForm.get('conversionUnit').value)
    .set('value', this.conversionForm.get('temperatureToConvert').value);

  return this.dataService.get(`${environment.temperatureConversionServiceUri}/temperature/convert`, params).subscribe((response) =>{
      if(response){
        this.convertedValue = response;
      }
    }  
    );
  }
}
