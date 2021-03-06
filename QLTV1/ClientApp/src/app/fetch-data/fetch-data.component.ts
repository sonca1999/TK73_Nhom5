import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public Theloai: any=[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>('https://localhost:44304/' + 'Weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
    http.post('https://localhost:44304/'​+'api/Theloai/get-all', null).subscribe(result => {
      this.Theloai = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
