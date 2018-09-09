import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from '@angular/cdk/layout';
import { AppMaterialModule } from './app-material/app-material.module';
import { AlertModule } from './alert/alert.module';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    LayoutModule
  ],
  declarations: [
    
  ],
  exports: [ AppMaterialModule, AlertModule ]
})
export class CoreModule { }
