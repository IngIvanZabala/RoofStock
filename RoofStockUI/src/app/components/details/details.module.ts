import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailsComponent } from './details/details.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [DetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ],
  exports: [
    DetailsComponent
  ]
})
export class DetailsModule { }
