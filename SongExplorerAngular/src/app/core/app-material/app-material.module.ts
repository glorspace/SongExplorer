import { NgModule } from '@angular/core';
import { 
  MatButtonModule, 
  MatCheckboxModule, 
  MatIconModule, 
  MatListModule, 
  MatToolbarModule, 
  MatMenuModule, 
  MatSidenavModule,
  MatCardModule,
  MatDividerModule,
  MatFormFieldModule,
  MatInputModule
} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  imports: [
    MatButtonModule, 
    MatCheckboxModule, 
    MatToolbarModule, 
    MatMenuModule, 
    MatSidenavModule, 
    MatIconModule, 
    MatListModule,
    FlexLayoutModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule
  ],
  exports: [
    MatButtonModule, 
    MatCheckboxModule, 
    MatToolbarModule, 
    MatMenuModule, 
    MatSidenavModule, 
    MatIconModule, 
    MatListModule,
    FlexLayoutModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class AppMaterialModule { }