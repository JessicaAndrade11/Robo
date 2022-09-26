import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:7071/api/robo';

@Injectable({
    providedIn: 'root'
})

export class RoboService {

    constructor(private http: HttpClient) { }

    create(): Observable<any> {
        return this.http.get(baseUrl);
    }
}