import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: 'create.component.html',
    moduleId: module.id
})

export class ClientCreateComponent {
    client: ClientCreate = new ClientCreate();

    constructor(private apiService: ApiService, private router: Router) {
    }

    create = () => {
        this.apiService.postData("Client", this.client, () => {
            this.router.navigate(['/client-list']);
        });
    }
}

export class ClientCreate {
    constructor() { }
    code: string;
    name: string;
    email: string;
    document : string;
    phone: string;
}