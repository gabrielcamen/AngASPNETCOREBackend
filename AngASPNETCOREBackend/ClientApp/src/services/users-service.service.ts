import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Users } from 'src/app/models/Users';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}


@Injectable({
  providedIn: 'root'
})
export class UsersServiceService {

  usersUrl: string = 'https://localhost:44306/users';

  constructor(private http: HttpClient) {
  }

  getUsers(): Observable<Users[]> {
    return this.http.get<Users[]>(this.usersUrl);
  }
}
