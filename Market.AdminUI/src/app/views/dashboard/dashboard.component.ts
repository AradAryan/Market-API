import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';

import { ProdcutApiService } from 'src/app/services/product/prodcut-service.service'

@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss']
})
export class DashboardComponent {
  constructor(private productApiService: ProdcutApiService) {
  }

  onCreateProduct() {
    console.log('call');
    this.productApiService.createProduct({ id: '3fa85f64-5717-4562-b3fc-2c963f66afa6', name: 'string', description: 'string', brandId: '3fa85f64-5717-4562-b3fc-2c963f66afa6' });

  }

}
