import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: 'detail.component.html',
    moduleId: module.id
})

export class ClientDetailComponent {
    router: Router;
    id: string;
    client: any;

    constructor(private apiService : ApiService, private route : ActivatedRoute, router : Router) {
        this.id = route.snapshot.paramMap.get('id');
        this.router = router;
    }

    ngOnInit() {
        this.apiService.getData<ClientDetail>("Client/?id=" + this.id, (data: ClientDetail) => {
            this.client = data;
        });        
    }

    update = () => {
        this.apiService.putData("Client/?id=" + this.id, () => {
            this.router.navigate(['/client-list', this.id]);
        });   
    }
}

export class ClientDetail {
    id: string;
    name: string;
}