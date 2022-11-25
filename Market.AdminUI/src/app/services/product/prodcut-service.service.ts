import { Injectable } from '@angular/core';
import { BaseApiServiceService } from 'src/app/services/apiServiceBase/base-api-service.service';
@Injectable({
  providedIn: 'root'
})
export class ProdcutApiService {

  constructor(private apiService: BaseApiServiceService) {
  }

  createProduct(products: { id: string, name: string, description: string, brandId: string }) {
    console.log(this.apiService.post(products, 'Product/AddProduct'));
  }

  fetchProduct() {

  }

  deleteProduct() {

  }

}
