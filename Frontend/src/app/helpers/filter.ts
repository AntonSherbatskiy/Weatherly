import {Injectable} from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class Filter {
  public searchTerm?: string;
}
