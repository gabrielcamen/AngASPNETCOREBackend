import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ListComponentComponent } from '../component/list-component/list-component.component';
import { ListItemComponent } from './components/list-item/list-item.component';
  

@NgModule({
  declarations: [
    AppComponent,
    ListComponentComponent,
    ListItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,

    /*
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
    */
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
