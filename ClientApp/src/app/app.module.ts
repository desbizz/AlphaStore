import { ConfigurationService } from './configuration.service';
import { ListSuppliersComponent } from './list-suppliers/list-suppliers.component';
import { ListProductComponent } from './list-product/list-product.component';
import { ListCategoryComponent } from './list-category/list-category.component';
import { AddSupplierComponent } from './add-supplier/add-supplier.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AddProductComponent } from './add-product/add-product.component';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    AddProductComponent,
    AddCategoryComponent,
    AddSupplierComponent,
    ListCategoryComponent,
    ListProductComponent,
    ListSuppliersComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
   
    
    
    RouterModule.forRoot([
     { path: 'addproduct', component: AddProductComponent, pathMatch: 'full' },
     { path: 'addcategory', component: AddCategoryComponent, pathMatch: 'full' },
     { path: 'addsupplier', component: AddSupplierComponent, pathMatch: 'full' },
     { path: 'listproduct', component: ListProductComponent, pathMatch: 'full' },
     { path: 'listcategory', component: ListCategoryComponent, pathMatch: 'full' },
     { path: 'listsupplier', component: ListSuppliersComponent, pathMatch: 'full' },

    ])
  ],
  providers: [
    ConfigurationService
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
