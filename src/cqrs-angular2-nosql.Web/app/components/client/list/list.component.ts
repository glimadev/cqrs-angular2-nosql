import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';

@Component({
    templateUrl: 'list.component.html',
    moduleId: module.id
})

export class ClientListComponent {
    constructor(private apiService: ApiService) {

    }

    clients: any;

    ngOnInit() {
        this.apiService.getData<Client>("Client", (data: Client) => {
            this.clients = data;
        });
    }
}

export class Client {
    id: string;
    name: string;
}