import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from 'src/app/models/response-model.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseApiServiceService {

  constructor(private http: HttpClient) {
  }

  post(data: any, actionUrl: string): ResponseModel {
    const headers = new HttpHeaders(
      {
        'Authorization':
          environment.tokenType + localStorage.getItem(environment.tokenTag)
      }
    );
    var result: any;
    this.http.post<ResponseModel>(
      environment.apiOriginUrl + actionUrl, data, { headers: headers })
      .subscribe((res) => {
        console.log(res);
        result = new ResponseModel(res.data, res.data, res.message);
      });
    return result;
  }

}
