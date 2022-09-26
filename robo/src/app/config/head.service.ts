import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


const baseUrl = 'https://localhost:7071/api/head';

@Injectable({
  providedIn: 'root'
})
export class HeadService {

  constructor(private http: HttpClient) { }


  updateRotation(data: any, headRotation: number): Observable<any> {
    return this.http.put(`${baseUrl}/rotation/${headRotation}`, data);
  }

  updateTilt(data: any, tilt: number): Observable<any> {
    return this.http.put(`${baseUrl}/tilt/${tilt}`, data);
  }


}