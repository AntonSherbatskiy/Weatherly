import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Weather} from "../models/weather";
import {map, Observable} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class WeatherService {
  constructor(private http: HttpClient) {
  }
  private getWeather(url: string): Observable<Weather[]> {
    return this.http.get<any>(url)
      .pipe(
        map((response: any) => {
          let oldDate = new Date(response[0].date * 1000).getDay();
          let index = 0;
          const weatherData: Weather[] = [];
          for (const item of response) {
            let newDate = new Date(item.date * 1000).getDay();
            if (newDate !== oldDate || index === 0) {
              oldDate = newDate;

              weatherData.push({
                temp: item.temperature,
                humidity: item.humidity,
                cloudStatus: item.cloudStatus,
                date: new Date(item.date * 1000),
                pressure: item.pressure,
                city: item.city,
                wind: item.windSpeed
              });
            }
            index++;
          }
          return weatherData;
        })
      );
  }

  public getWeather3DaysByCoordinates(latitude: number, longitude: number): Observable<Weather[]> {
    return this.getWeather(`/api/v1/weather/${latitude}/${longitude}`);
  }

  public getWeather3DaysByCity(city: string): Observable<Weather[]> {
    return this.getWeather(`/api/v1/weather/${city}`);
  }
}
