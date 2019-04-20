import { ConfigurationService } from './../configuration.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})
export class ListCategoryComponent implements OnInit {
  categories:any;
  constructor(private configurationService:ConfigurationService) { }

  ngOnInit() {

    this.configurationService.ListCategory()
    .subscribe(result => this.categories = result);

  }

}
