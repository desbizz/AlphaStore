import { ListStoreComponent } from './Components/list-store/list-store.component';
import { ConfigurationService } from './Services/configuration.service';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { HttpModule } from '@angular/http';
import { AddProductComponent } from './Components/add-product/add-product.component';
import { AddCategoryComponent } from './Components/add-category/add-category.component';
import { AddSupplierComponent } from './Components/add-supplier/add-supplier.component';
import { ListCategoryComponent } from './Components/list-category/list-category.component';
import { ListProductComponent } from './Components/list-product/list-product.component';
import { ListSuppliersComponent } from './Components/list-suppliers/list-suppliers.component';
import { AddStoreComponent } from './Components/add-store/add-store.component';


@NgModule({
  declarations: [
    AppComponent,
    AddProductComponent,
    AddCategoryComponent,
    AddSupplierComponent,
    ListCategoryComponent,
    ListProductComponent,
    ListSuppliersComponent,
    AddStoreComponent,
    ListStoreComponent

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
     { path: 'addstore', component: AddStoreComponent, pathMatch: 'full' },
     { path: 'editproduct/:id', component: AddProductComponent, pathMatch: 'full' },
     { path: 'editcategory/:id', component: AddCategoryComponent, pathMatch: 'full' },
     { path: 'editsupplier/:id', component: AddSupplierComponent, pathMatch: 'full' },
     { path: 'editstore/:id', component: AddStoreComponent, pathMatch: 'full' },
     { path: 'listproduct', component: ListProductComponent, pathMatch: 'full' },
     { path: 'listcategory', component: ListCategoryComponent, pathMatch: 'full' },
     { path: 'listsupplier', component: ListSuppliersComponent, pathMatch: 'full' },
     { path: 'liststore', component: ListStoreComponent, pathMatch: 'full' },


    ])
  ],
  providers: [
    ConfigurationService
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
