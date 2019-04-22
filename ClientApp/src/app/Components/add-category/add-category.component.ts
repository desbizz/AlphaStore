
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { KeyValuePair } from 'src/app/Models/keyvaluepair';
import { ConfigurationService } from 'src/app/Services/configuration.service';


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
  
    private configurationService:ConfigurationService) {
      route.params.subscribe(p => {
        this.category.id = +p['id'];
    })
     }

  ngOnInit() {

    if(!this.category.id)
    this.category.id=0;
    this.configurationService.GetCategory(this.category.id)
    .subscribe(categ => this.category = categ);


    
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
