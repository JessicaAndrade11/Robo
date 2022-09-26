import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Head } from '../models/head.model';


const baseUrl = 'https://localhost:7071/api/head';

@Injectable({
  providedIn: 'root'
})
export class HeadService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Head[]> {
    return this.http.get<Head[]>(baseUrl);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  updateRotation(data: any, headRotation: number): Observable<any> {
    return this.http.put(`${baseUrl}/rotation/${headRotation}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  deleteAll(): Observable<any> {
    return this.http.delete(baseUrl);
  }

  findByTitle(title: any): Observable<Head[]> {
    return this.http.get<Head[]>(`${baseUrl}?title=${title}`);
  }
}