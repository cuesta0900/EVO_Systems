import { Funcionario } from './../models/Funcionario';
import { Departamento } from './../models/Departamento';
import { DepartamentoService } from './departamento.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-depts',
  templateUrl: './depts.component.html',
  styleUrls: ['./depts.component.css']
})
export class DeptsComponent implements OnInit {
  public deptForm!: FormGroup;
  public titulo = 'Departamentos';
  public deptSelecionado!: Departamento;
  public tabela: boolean = true;
  public shfunc: boolean = false;
  public deptos!: Departamento[];
  public funcs!: Funcionario[];
  constructor(private fb: FormBuilder,
              private departamentoService: DepartamentoService){
                this.criarForm();
              }

  ngOnInit() {
    this.carregarDepartamentos();
  }

  carregarDepartamentos(){
    this.departamentoService.getAll().subscribe(
      (deptos : Departamento[]) =>{
        this.deptos = deptos;
      },
      (erro: any) => {console.error(erro)}
    );
  }

  consultarFuncs(dept: Departamento){
    this.deptSelecionado = dept;
    this.tabela = false;
    this.shfunc = true;
    this.deptForm.patchValue(dept);
    this.departamentoService.getFunc(dept.id).subscribe(
      (funcs : Funcionario[]) => {this.funcs = funcs},
      (erro: any) => {console.error(erro)}
    );
  }

  deletar(id: number){
    this.departamentoService.delete(id).subscribe(
      (model: any)=> {console.log(model),
      this.carregarDepartamentos()},
      (erro: any)=> {console.log(erro)}
    );
}

  criarForm(){
    this.deptForm = this.fb.group({
      id:[''],
      nome:['', Validators.required],
      sigla:['', Validators.required]
    });
  }

  salvarDept(dept: Departamento){
    if(dept.id === 0){
      this.departamentoService.post(dept).subscribe(
        () => {
          console.log("deptionário Cadastrado");
          this.carregarDepartamentos();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }else{
      this.departamentoService.put(dept).subscribe(
        () => {
          console.log("Dados Atualizados");
          this.carregarDepartamentos();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }
  }


  deptSubmit(){
    this.salvarDept(this.deptForm.value);
  }

  deptSelect(dept: Departamento){
    this.deptSelecionado = dept;
    this.tabela = false;
    this.shfunc = false;
    this.deptForm.patchValue(dept);
  }

  departamentoNovo(){
    this.deptSelecionado = new Departamento;
    this.tabela = false;
    this.shfunc = false;
    this.deptForm.patchValue(this.deptSelecionado);
  }

voltar(){
    this.tabela = true;
}

}
