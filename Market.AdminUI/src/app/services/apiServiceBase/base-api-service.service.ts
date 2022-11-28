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

  async post(data: any, actionUrl: string): Promise<ResponseModel | undefined> {
    const headers = new HttpHeaders({ 'Authorization': environment.tokenType + localStorage.getItem(environment.tokenTag) });
    return await this.http.post<ResponseModel>(environment.apiOriginUrl + actionUrl, data, { headers: headers }).toPromise();
  }

  async get(actionUrl: string): Promise<ResponseModel | undefined> {
    const headers = new HttpHeaders({ 'Authorization': environment.tokenType + localStorage.getItem(environment.tokenTag) });
    return await this.http.get<ResponseModel>(environment.apiOriginUrl + actionUrl, { headers: headers }).toPromise()
  }

  async put(data: any, actionUrl: string): Promise<ResponseModel | undefined> {
    const headers = new HttpHeaders({ 'Authorization': environment.tokenType + localStorage.getItem(environment.tokenTag) });
    return await this.http.put<ResponseModel>(environment.apiOriginUrl + actionUrl, data, { headers: headers }).toPromise();
  }

  async delete(actionUrl: string, id: string): Promise<ResponseModel | undefined> {
    const headers = new HttpHeaders({ 'Authorization': environment.tokenType + localStorage.getItem(environment.tokenTag) });
    return await this.http.post<ResponseModel>(environment.apiOriginUrl + actionUrl, id, { headers: headers }).toPromise();
  }

}
