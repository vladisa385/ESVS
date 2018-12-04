import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { NavMenuService} from "./nav-authorization.service";

@Component({
  selector: 'app-nav-authorization',
  templateUrl: './nav-authorization.component.html',
  styleUrls: ['./nav-authorization.component.css']
})
export class NavAuthorizationComponent {
  constructor(private navMenuService: NavMenuService) { }

  signin() {

  }

  onSubmit() {

  }
}
