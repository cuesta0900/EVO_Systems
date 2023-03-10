/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DeptsComponent } from './depts.component';

describe('DeptsComponent', () => {
  let component: DeptsComponent;
  let fixture: ComponentFixture<DeptsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeptsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeptsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
