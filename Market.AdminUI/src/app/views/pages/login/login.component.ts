import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication/authentication-service.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private auth: AuthenticationService, private router: Router) { }

  async Login(username: string, password: string) {
    console.log(username, password);
    let result = await this.auth.Login(username, password);
    if (result.succeed == true)
      this.router.navigate(['Dashboard']);
    else alert(result.message);
  }
}
