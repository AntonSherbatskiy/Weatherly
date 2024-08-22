import {Routes} from "@angular/router";
import {
  WeatherSelectorListComponent
} from "../components/weather-container/weather-selector-list/weather-selector-list.component";
import {WeatherCardComponent} from "../components/weather-container/weather-card/weather-card.component";

export const routes: Routes = [
  {
    path: "",
    component: WeatherSelectorListComponent
  },
  {
    path: "city/:city",
    component: WeatherCardComponent
  }
]
