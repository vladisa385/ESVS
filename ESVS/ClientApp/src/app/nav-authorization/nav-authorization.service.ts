import {Inject, Injectable} from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Observable } from "rxjs";
import {_throw} from "rxjs/observable/throw";
import { catchError, retry } from "rxjs/operators";

@Injectable()
export class NavMenuService {
  // public reply :string;
  //
  // constructor(private http: HttpClient) { };

  // signin(signInData: SignInData, @Inject('BASE_URL') baseUrl: string): Observable<SignInData> {
  //   return this.http.put<SignInData>(baseUrl, signInData, httpOptions)
  //     .pipe(
  //       catchError(this.handleError('signin', signInData))
  //     );
  // }

  // signin(signInData: SignInData, @Inject('BASE_URL') baseUrl: string): Observable<SignInData> {
  //   return this.http.put<SignInData>(baseUrl + 'api/Account/Login', signInData, httpOptions).subscribe(
  //     result => {
  //       console.log(result);
  //     }, error => console.error(error));
  // }
}

// const httpOptions = {
//   headers: new HttpHeaders({
//       'Content-Type': 'application/json',
//       'Authorization': 'my-auth-token'
//     }
//   )
// };
//
// export interface SignInData {
//   email: string;
//   password: string;
//   rememberme: boolean;
// }
