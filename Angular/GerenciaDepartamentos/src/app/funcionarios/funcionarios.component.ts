import { Departamento } from './../models/Departamento';
import { FuncionarioService } from './funcionario.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Funcionario } from '../models/Funcionario';


@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit{

  public funcForm!: FormGroup;
  public titulo = 'Funcionários';
  public tabela: boolean = true;
  public funcionarioSelecionado!: Funcionario;
  public funcs!: Funcionario[];
  ngOnInit(){
    this.carregarFuncionarios();
  }

  constructor(private fb: FormBuilder,
              private funcionarioService : FuncionarioService){
    this.criarForm();
  }

  criarForm(){
    this.funcForm = this.fb.group({
      id: [''],
      nome:['', Validators.required],
      rg:['', Validators.required],
      departamentoid:['', Validators.required]
    });
  }

  salvarFuncionario(func: Funcionario){
    if(func.id === 0){
      this.funcionarioService.post(func).subscribe(
        () => {
          console.log("Funcionário Cadastrado");
          this.carregarFuncionarios();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }else{
      this.funcionarioService.put(func).subscribe(
        () => {
          console.log("Dados Atualizados");
          this.carregarFuncionarios();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }
  }


  funcSubmit(){
    this.salvarFuncionario(this.funcForm.value);
  }

  funcSelect(func: Funcionario){
    this.funcionarioSelecionado = func;
    this.tabela = false;
    this.funcForm.patchValue(func);
  }

  funcNovo(){
    this.funcionarioSelecionado = new Funcionario();
    this.tabela = false;
    this.funcForm.patchValue(this.funcionarioSelecionado);
  }

  carregarFuncionarios(){
    this.funcionarioService.getAll().subscribe(
      (funcs : Funcionario[]) =>{
        this.funcs = funcs;
      },
      (erro: any) => {console.error(erro)}
    );
  }

  deletar(id: number){
      this.funcionarioService.delete(id).subscribe(
        (model: any)=> {console.log(model),
        this.carregarFuncionarios()},
        (erro: any)=> {console.log(erro)}
      );
  }

voltar(){
    this.tabela = true;
}


}
