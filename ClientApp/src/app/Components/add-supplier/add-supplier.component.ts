import { Component, OnInit } from '@angular/core';
import { Supplier } from 'src/app/Models/supplier';
import { Router, ActivatedRoute } from '@angular/router';
import { ConfigurationService } from 'src/app/Services/configuration.service';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {

  supplier: Supplier = {
    id: 0,
    supplierName: "",
    phoneNumber: "",
    email: ""
  };
  constructor(private route: ActivatedRoute,

    private router: Router,

    private configurationService: ConfigurationService) {
      route.params.subscribe(p => {
        this.supplier.id = +p['id'];
    });

     }

  ngOnInit() {
    this.configurationService.GetSupplier(this.supplier.id)
    .subscribe(categ => this.supplier = categ);


  }

  submit() {
    if (this.supplier.id) {

      this.configurationService.UpdateSupplier(this.supplier)
          .subscribe(x => {
          });

  } else {

      this.configurationService.createSupplier(this.supplier)

          .subscribe(x => {


          });

  }
 // this.router.navigate(['listsupplier']);
  }

}
