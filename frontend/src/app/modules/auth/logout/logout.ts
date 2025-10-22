import { Component } from '@angular/core';
import {Router} from '@angular/router';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';

@Component({
  selector: 'logout',
  templateUrl: './logout.html',
  styleUrls: ['./logout.scss'],
  standalone: false
})

export class Logout {
  constructor(private authService:MyAuthService, private router:Router) {
    this.logout();
  }
  logout(){
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}

