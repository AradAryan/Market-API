import { Injectable } from '@angular/core';
import { BaseApiServiceService } from 'src/app/services/apiServiceBase/base-api-service.service';

@Injectable({
  providedIn: 'root'
})
export class ProdcutApiService {

  constructor(private apiService: BaseApiServiceService) { }

  createProduct(product: { id: string, name: string, description: string, brandId: string }) {
    let res = this.apiService.post(product, 'Product/AddProduct');
    return res.data;
  }

  fetchProduct() {
    let res = this.apiService.get('Product/GetAllProducts');
    return res.data;
  }

  updateProduct(product: { id: string, name: string, description: string, brandId: string }) {
    let res = this.apiService.post(product, 'Product/UpdateProduct');
    return res.data;
  }

  deleteProductById(id: string) {
    let res = this.apiService.get('Product/RemoveProductById');
    return res.data;
  }

  getById(id: string) {
    let res = this.apiService.post(id, 'Product/GetProductById');
    return res.data;
  }
}
