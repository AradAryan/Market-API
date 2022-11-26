import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication/authentication-service.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private auth: AuthenticationService, private router: Router) { }

  async Register(username: string, email: string, password: string, rPassword: string, phoneNumber: string) {
    if (password === rPassword) {
      let result = await this.auth.Register(username, email, password, phoneNumber);
      if (result.succeed == true)
        this.router.navigate(['Login']);
      else alert(result.message);
    }
    else alert('Passwords Are not Match');
  }
}
