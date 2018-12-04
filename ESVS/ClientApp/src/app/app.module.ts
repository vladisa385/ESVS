import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { AngularFontAwesomeModule } from "angular-font-awesome";

import { AppComponent } from './app.component';
import { NavAuthorizationComponent } from "./nav-authorization/nav-authorization.component";
import { NavMenuService} from "./nav-authorization/nav-authorization.service";
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from "./about/about.component";
import { ContactsComponent } from "./contacts/contacts.component";
import { BottomBarComponent } from "./bottom-bar/bottom-bar.component";

@NgModule({
  declarations: [
    AppComponent,
    NavAuthorizationComponent,
    NavMenuComponent,
    HomeComponent,
    AboutComponent,
    ContactsComponent,
    BottomBarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AngularFontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'about', component: AboutComponent },
      { path: 'contacts', component: ContactsComponent }
    ])
  ],
  providers: [
    NavMenuService
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
