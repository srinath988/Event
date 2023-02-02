import { ContactComponent } from './EventComponent/contact/contact.component';
import { EventListComponent } from './EventComponent/event-list/event-list.component';
import { EventAddComponent } from './EventComponent/event-add/event-add.component';
import { EventHomeComponent } from './EventComponent/event-home/event-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventResolver } from './event.resolver';

const routes: Routes = [
  {
    path: 'home',
    component: EventHomeComponent,
  },
  {
    path: 'addevent',
    component: EventAddComponent,
  },
  {
    path: 'eventlist',
    component: EventListComponent,
    resolve: { message: EventResolver },
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: '',
    component: EventHomeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
