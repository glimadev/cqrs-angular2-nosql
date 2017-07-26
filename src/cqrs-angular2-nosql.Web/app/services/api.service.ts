import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { ToastrService } from 'ngx-toastr';

@Injectable()

export class ApiService {
    headers: Headers;
    options: RequestOptions;

    constructor(private http: Http, public toastrService: ToastrService) {
        this.headers = new Headers({'Content-Type': 'application/json','Accept': 'q=0.8;application/json;q=0.9'});
        this.options = new RequestOptions({ headers: this.headers });
    }

    getData<T>(endpoint:string, callback? : (data: T)=>void) {
        this.http.get('/api/' + endpoint, this.options).subscribe(response => {
            this.getResponse<T>(response.json(), false, callback);
        });
    }

    postData(endpoint: string, body: any, callback?: () => void) {
        this.http.post('/api/' + endpoint, body).subscribe(response => {
            this.getResponse(response.json(), true, callback);
        });
    }

    putData(endpoint: string, body: any, callback?: () => void) {
        this.http.put('/api/' + endpoint, body).subscribe(response => {
            this.getResponse(response.json(), true, callback);
        });
    }

    deleteData(endpoint: string, callback?: () => void) {
        this.http.delete('/api/' + endpoint).subscribe(response => {
            this.getResponse(response.json(), true, callback);
        });
    }

    private getResponse<T>(response: ResultService<T>, showSuccess: boolean, callback?: (data: T) => void) {
        if (response.success) {
            if (showSuccess) {
                this.toastrService.success('Comando realizado', 'Sucesso!');
            }

            return callback ? callback(response.data) : 1;
        }

        this.toastrService.info(response.messages.join(", "),'Info!');
    }
}

export class ResultService<T> {
    messages: string[];
    success: boolean;
    data: T;
}
