import { Injectable } from '@angular/core';
import { BaseApiServiceService } from 'src/app/services/apiServiceBase/base-api-service.service';

@Injectable({
  providedIn: 'root'
})
export class ProdcutApiService {

  constructor(private apiService: BaseApiServiceService) { }

  async createProduct(product: { id: string, name: string, description: string, brandId: string }) {
    let res = await this.apiService.post(product, 'Product/AddProduct');
    return res?.data;
  }

  async fetchProducts() {
    let res = await this.apiService.get('Product/GetAllProducts');
    return res?.data;
  }

  async updateProduct(product: { id: string, name: string, description: string, brandId: string }) {
    let res = await this.apiService.post(product, 'Product/UpdateProduct');
    return res?.data;
  }

  async deleteProductById(id: string) {
    let res = await this.apiService.get('Product/RemoveProductById');
    return res?.data;
  }

  async getById(id: string) {
    let res = await this.apiService.post(id, 'Product/GetProductById');
    return res?.data;
  }
}
