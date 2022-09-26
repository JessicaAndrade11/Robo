import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


const baseUrl = 'https://localhost:7071/api/leftArm';

@Injectable({
  providedIn: 'root'
})
export class LeftArmService {

  constructor(private http: HttpClient) { }

  updateElbowContraction(data: any, contraction: number): Observable<any> {
    return this.http.put(`${baseUrl}/elbow/contraction/${contraction}`, data);
  }

  updateWristRotation(data: any, armRotation: number): Observable<any> {
    return this.http.put(`${baseUrl}/wrist/rotation/${armRotation}`, data);
  }

}