import { Injectable } from '@angular/core';
import { BaseApiServiceService } from 'src/app/services/apiServiceBase/base-api-service.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProdcutApiService {

  constructor(private apiService: BaseApiServiceService, private router: Router) {
  }

  createProduct(products: { id: string, name: string, description: string, brandId: string }) {
    this.router.navigate(['Login']);
    //console.log(this.apiService.post(products, 'Product/AddProduct'));
  }

  fetchProduct() {

  }

  deleteProduct() {

  }

}
