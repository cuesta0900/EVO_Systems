import { Funcionario } from '../models/Funcionario';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {
  baseUrl = "http://localhost:5023/api/Funcionario";
  constructor(private http: HttpClient) { }

  private _apiURL = '/api';
  private _httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
      'Access-Control-Allow-Headers':
        'Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers'
    })
  };

  getAll() : Observable<Funcionario[]>{
    return this.http.get<Funcionario[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Funcionario>{
    return this.http.get<Funcionario>(`${this.baseUrl}/${id}`);
  }


  post(funcionario: Funcionario){
    return this.http.post(`${this.baseUrl}`, funcionario);
  }

  put(funcionario: Funcionario){
    return this.http.put(`${this.baseUrl}/${funcionario.id}`, funcionario);
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
