import {Component, ElementRef, input, ViewChild} from '@angular/core';
import {Filter} from "../../../../helpers/filter";
import {Router} from "@angular/router";
import {routes} from "../../../../config/routes";

@Component({
  selector: 'app-weather-search',
  templateUrl: './weather-search.component.html',
  styleUrl: './weather-search.component.css'
})
export class WeatherSearchComponent {
  constructor(private filter: Filter, private router: Router) {
  }

  @ViewChild("searchInput") input?: ElementRef;

  protected searchButtonClicked() {
    this.filter.searchTerm = this.input!.nativeElement.value;
    this.router.navigate(["city", this.filter.searchTerm]);
  }

  protected inputEnter() {

  }
}
