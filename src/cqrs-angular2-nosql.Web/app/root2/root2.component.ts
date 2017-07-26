import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
    templateUrl: 'root2.component.html',
    moduleId: module.id
})

export class Root2Component {
    constructor(private apiService: ApiService) {

    }
    
    ngOnInit() {
        this.apiService.getData<Client>("Client", (data: Client) => {
            console.log(data);
        });
    }
}

export class Client {
    id: string;
    name: string;
}