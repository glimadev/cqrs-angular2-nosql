import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()

export class ApiService {

    constructor(private http: Http) {

    }

    getData<T>(endpoint:string, callback:(data: T)=>void) {
        this.http.get('/api/' + endpoint).subscribe(response => {
            this.getResponse<T>(response.json(), callback);
        });
    }

    private getResponse<T>(response: ResultService<T>, callback: (data: T) => void) {
        if (response.success) {
            callback(response.data);
        }
    }
}


export class ResultService<T> {
    messages: string[];
    success: boolean;
    data: T;
}
