import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WeatherForecast } from '../models/weatherForecast';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {

  private url = "http://localhost:5000/api/WeatherForecast";

  constructor(private http: HttpClient) { }

  getWeatherForecasts(): Observable<WeatherForecast[]>{
    return this.http.get<WeatherForecast[]>(this.url);
  }
}
