import { KeyValuePair } from './Models/keyvaluepair';
import { SaveProduct } from './Models/product';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  constructor(private http: Http) { }

  createPayment(product) {
   
    return this.http.post('/api/payment', product)
    .pipe(map((response: any) => response.json()));
        
}
UpdatePayment(payment:SaveProduct) {
   
  return this.http.put('/api/payment/'+ payment.id, payment)
  .pipe(map((response: any) => response.json()));
      
}
ListPayment() {
  return this.http.get('/api/payment')
  .pipe(map((response: any) => response.json()));
  }
  GetPayment(id) {
    return this.http.get('/api/payment/' + id)
    .pipe(map((response: any) => response.json()));
    }
createCategory(category) {
   
  return this.http.post('/api/category', category)
  .pipe(map((response: any) => response.json()));
      
}
UpdateCategory(category:KeyValuePair) {
 
return this.http.put('/api/category/'+ category.id, category)
.pipe(map((response: any) => response.json()));
    
}
ListCategory() {
  return this.http.get('/api/category')
  .pipe(map((response: any) => response.json()));
  }
  GetCategory(id) {
    return this.http.get('/api/category/' + id)
    .pipe(map((response: any) => response.json()));
    }

}
