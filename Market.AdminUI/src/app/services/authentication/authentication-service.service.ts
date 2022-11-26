import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from 'src/app/models/response-model.model';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) {
  }

  public async Login(username: string, password: string): Promise<ResponseModel> {
    try {
      var res = await this.http.post<ResponseModel>(environment.apiLoginUrl, { username, password }, { headers: new HttpHeaders() }).toPromise();
      localStorage.setItem(environment.tokenTag, res?.data.token);
      return res || new ResponseModel(false, null, 'Unknown Error');
    } catch (e) {
      return res || new ResponseModel(false, e, 'Unknown Error');
    }
  }

}
