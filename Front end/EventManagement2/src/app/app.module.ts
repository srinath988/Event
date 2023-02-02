import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventHomeComponent } from './EventComponent/event-home/event-home.component';
import { EventListComponent } from './EventComponent/event-list/event-list.component';
import { EventAddComponent } from './EventComponent/event-add/event-add.component';
import { EventNavbarComponent } from './EventComponent/event-navbar/event-navbar.component';
import { ContactComponent } from './EventComponent/contact/contact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
@NgModule({
  declarations: [
    AppComponent,
    EventHomeComponent,
    EventListComponent,
    EventAddComponent,
    EventNavbarComponent,
    ContactComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPaginationModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
