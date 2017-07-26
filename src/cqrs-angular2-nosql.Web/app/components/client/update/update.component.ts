import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: 'update.component.html',
    moduleId: module.id
})

export class ClientUpdateComponent {
    id: string;
    client: any;

    constructor(private apiService: ApiService, route: ActivatedRoute, private router: Router) {
        this.id = route.snapshot.paramMap.get('id');
    }

    ngOnInit() {
        this.apiService.getData<ClientUpdate>("Client/?id=" + this.id, (data: ClientUpdate) => {
            this.client = data;
        });
    }

    update = () => {
        this.apiService.putData("Client/?id=" + this.id, this.client);
    }
}

export class ClientUpdate {
    id: string;
    name: string;
}