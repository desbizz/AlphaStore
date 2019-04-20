import { KeyValuePair } from './../Models/keyvaluepair';
import { ConfigurationService } from './../configuration.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  category:KeyValuePair={
    id:0,
    name:""
  };
  ;
  constructor(private route: ActivatedRoute,
    
    private router:Router,
  
    private configurationService:ConfigurationService) { }

  ngOnInit() {


    
  }
  submit() {
  
    if (this.category.id) {
    
     this.configurationService.UpdateCategory(this.category)
         .subscribe(x => { 
         });
 
 } else {
    
     this.configurationService.createCategory(this.category)
 
         .subscribe(x => {
            
          // this.router.navigate(['studentpage/' + this.payment.studentId]);
         });
     
 }
 this.router.navigate(['addcategory']);
   }


}
