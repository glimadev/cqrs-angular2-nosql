import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';

@Component({
    templateUrl: 'list.component.html',
    moduleId: module.id
})

export class ClientListComponent {

    clients: any;

    constructor(private apiService: ApiService) {

    }

    ngOnInit() {
        this.get();
    }

    get = () => {
        this.apiService.getData<ClientList>("Client", (data: ClientList) => {
            this.clients = data;
        });
    }

    delete = (id:string) => {
        this.apiService.deleteData("Client/?id=" + id, () => this.get());
    }
}

export class ClientList {
    id: string;
    name: string;
}