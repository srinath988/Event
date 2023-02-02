import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private http: HttpClient) {}
  webapiput = 'https://localhost:44364/api/ContactInfo/insertcontactinfo';

  postdata(data: any) {
    return this.http.post<any>(
      'https://localhost:44364/api/ContactInfo/insertcontactinfo',
      data
    );
  }
}
