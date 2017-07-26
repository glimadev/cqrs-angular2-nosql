import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: 'detail.component.html',
    moduleId: module.id
})

export class ClientDetailComponent {

    id: string;
    client: any;

    constructor(private apiService: ApiService, private route: ActivatedRoute) {
        this.id = route.snapshot.paramMap.get('id');
    }

    ngOnInit() {
        this.apiService.getData<Client>("Client/?id=" + this.id, (data: Client) => {
            this.client = data;
        });        
    }
}

export class Client {
    id: string;
    name: string;
}