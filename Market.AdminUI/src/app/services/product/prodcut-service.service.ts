import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ProdcutApiService {

  constructor(private http: HttpClient) { }

  createProduct(products: { name: string }) {
    console.log('products');
    const headers = new HttpHeaders({ 'myHeader': 'procademy' });
    this.http.post<{ name: string }>(
      '', products, { headers: headers })
      .subscribe((res) => {
        console.log(res);
      });

  }

  fetchProduct() {

  }

  deleteProduct() {

  }

}
