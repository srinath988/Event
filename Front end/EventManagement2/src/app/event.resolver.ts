import { Injectable } from '@angular/core';
import {
  Router,
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { EventService } from './services/event.service';

@Injectable({
  providedIn: 'root',
})
export class EventResolver implements Resolve<any> {
  constructor(private eventService: EventService) {}
  resolve(): Observable<any> {
    return this.eventService.getdata();
  }
}
