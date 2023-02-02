import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Event } from '../Models/Event.model';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  webapi = 'https://localhost:44364/api/Event/';
  webapipost = 'https://localhost:44364/api/Event/';
  webapiput = 'https://localhost:44364/api/Event/{id}';
  api = 'https://localhost:44364/api/Event/';
  webap = 'https://localhost:44364/api/Event/searchByName';
  constructor(private http: HttpClient) {}

  getdata(): Observable<Array<Event>> {
    return this.http.get<Array<Event>>(this.webapi);
  }
  postdata(data: any) {
    return this.http.post(this.webapipost, data);
  }
  updatedata(id: any, data: any) {
    return this.http.put(this.webapiput, id, data);
  }

  SaveChanges(id: any, EventList: any) {
    console.log(EventList.Event);

    return this.http.put(`https://localhost:44364/api/Event/${id}`, EventList);
  }

  Delete(Id: any) {
    return this.http.delete(this.api + Id);
  }

  GetPerging(pNo: any, pSize: any): Observable<any> {
    return this.http.get(
      `https://localhost:44364/api/Event/page?PageNumber=${pNo}&PageSize=${pSize}`
    );
  }
  Search(name: string): Observable<Array<Event>> {
    return this.http.get<Array<Event>>(
      'https://localhost:44364/api/Event/searchByName?name=' + name
    );
  }
}
