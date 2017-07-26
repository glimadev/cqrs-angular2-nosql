import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';

@Injectable()

export class ApiService {
    headers: Headers;
    options: RequestOptions;

    constructor(private http: Http) {
        this.headers = new Headers({'Content-Type': 'application/json','Accept': 'q=0.8;application/json;q=0.9'});
        this.options = new RequestOptions({ headers: this.headers });
    }

    getData<T>(endpoint:string, callback:(data: T)=>void) {
        this.http.get('/api/' + endpoint, this.options).subscribe(response => {
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
