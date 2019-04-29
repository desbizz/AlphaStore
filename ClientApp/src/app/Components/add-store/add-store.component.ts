import { Store } from './../../Models/store';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfigurationService } from 'src/app/Services/configuration.service';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent implements OnInit {
  store:Store = {
    id: 0,
    name: "",
    address: "",
    address1: ""
};
  constructor(private route: ActivatedRoute,
    
    private router: Router,
  
    private configurationService: ConfigurationService ) {
      route.params.subscribe(p => {
        this.store.id = +p['id'];
    })

     }

  ngOnInit() {
    if(!this.store.id)
    this.store.id=0;
    this.configurationService.GetStore(this.store.id)
    .subscribe(categ => this.store = categ);



  }

  submit(){
    if (this.store.id) {
   this.configurationService.UpdateStore(this.store)
          .subscribe(x => {
          });

  } else {

      this.configurationService.createStore(this.store)

          .subscribe(x => {


          });

  }
  this.router.navigate(['liststore']);
  }

}
