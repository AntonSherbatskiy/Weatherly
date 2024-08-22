import { platformBrowser } from '@angular/platform-browser';
import {AppModule} from "./app/modules/app.module";

platformBrowser().bootstrapModule(AppModule)
.catch(err => console.log(err));
