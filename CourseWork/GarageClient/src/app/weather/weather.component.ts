import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private service:SharedService) { }

  WeatherList:any=[];
  
  ngOnInit(): void {
    this.refreshWeatherList();
  }

  refreshWeatherList(){
    this.service.getWeatherList().subscribe(data => {
      this.WeatherList = data;
    })
  }
}
