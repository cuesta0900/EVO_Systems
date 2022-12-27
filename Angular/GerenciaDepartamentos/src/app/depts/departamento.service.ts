import { Funcionario } from './../models/Funcionario';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departamento } from '../models/Departamento';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {
  baseUrl = "http://localhost:5023/api/Departamento";
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

  getAll() : Observable<Departamento[]>{
    return this.http.get<Departamento[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Departamento>{
    return this.http.get<Departamento>(`${this.baseUrl}/${id}`);
  }

  getFunc(id: number): Observable<Funcionario[]>{
    return this.http.get<Funcionario[]>(`http://localhost:5023/api/Funcionario/ByDept/${id}`);
  }

  post(departamento: Departamento){
    return this.http.post(`${this.baseUrl}`, departamento);
  }

  put(departamento: Departamento){
    return this.http.put(`${this.baseUrl}/${departamento.id}`, departamento);
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
