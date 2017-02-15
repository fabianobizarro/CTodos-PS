import { Injectable } from '@angular/core';
import { Perfil } from './model';
import { Http, Headers } from '@angular/http';
import { environment } from '../environments/environment';
import 'rxjs/add/operator/map';

@Injectable()
export class PerfilService {

  constructor(private http: Http) { }

  obterPerfis(): Promise<Perfil[]> {
    return new Promise((resolve, reject) => {

      let url = environment.api_endpoint + '/Perfil';
      this.http.get(url)
        .map(res => res.json())
        .subscribe(resolve, reject);
    });
  }

}
