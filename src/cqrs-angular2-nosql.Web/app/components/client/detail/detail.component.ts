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

    constructor(private apiService : ApiService, private route : ActivatedRoute) {
        this.id = route.snapshot.paramMap.get('id');
    }

    ngOnInit() {
        this.apiService.getData<ClientDetail>("Client/?id=" + this.id, (data: ClientDetail) => {
            this.client = data;
        });        
    }
}

export class ClientDetail {
    id: string;
    code: string;
    name: string;
    email: string;
    document: string;
    phone: string;
}