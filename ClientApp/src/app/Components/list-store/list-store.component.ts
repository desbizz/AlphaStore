import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from 'src/app/Services/configuration.service';

@Component({
  selector: 'app-list-store',
  templateUrl: './list-store.component.html',
  styleUrls: ['./list-store.component.css']
})
export class ListStoreComponent implements OnInit {
 store:any;
  constructor(private configurationService:ConfigurationService) { }

  ngOnInit() {
    this.configurationService.ListStore()
    .subscribe(result => this.store = result);
  }

}
