import {Component, OnInit} from '@angular/core';
import {Weather} from "../../../models/weather";
import {WeatherService} from "../../../services/weather.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-weather-card',
  templateUrl: './weather-card.component.html',
  styleUrl: './weather-card.component.css'
})
export class WeatherCardComponent implements OnInit {
  constructor(private weatherService: WeatherService, private activeRoute: ActivatedRoute, private router: Router) {
  }

  protected weatherList?: Weather[];
  protected selectedDay: number = 0;
  protected loaded: boolean = false;
  protected get selectedWeather(): Weather {
    return this.weatherList![this.selectedDay];
  }

  protected selectWeather(day: number): Weather {
    return this.weatherList![day];
  }

  protected navigateBack() {
    this.router.navigate(['/']);
  }

    ngOnInit(): void {
      this.selectedDay = 0;
      const city = this.activeRoute.snapshot.paramMap.get("city")!;

      if (city.toLowerCase() == 'current') {
        navigator.geolocation.getCurrentPosition(position => {
          const latitude = position.coords.latitude;
          const longitude = position.coords.longitude;

          this.weatherService.getWeather3DaysByCoordinates(latitude, longitude).subscribe(res => {
            this.weatherList = res;
          })
        })
      }
      else {
        this.weatherService.getWeather3DaysByCity(city).subscribe(res => {
          if (!res.length) {
            alert("City not found");
            this.router.navigate([""]);
            return;
          }
          this.weatherList = res;
        })
      }

      this.loaded = true;
    }

  protected readonly Date = Date;
  protected readonly alert = alert;
}
