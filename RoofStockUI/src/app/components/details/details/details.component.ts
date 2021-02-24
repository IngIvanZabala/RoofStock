import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { StockDataModel } from 'src/app/Models/stockData.model';
import { StockService } from '../../../services/stock.service';
import { SpinnerComponent } from '../../shared/spinner/spinner.component';
import Swal from 'sweetalert2';
import { BaseResponseModel } from 'src/app/Models/baseResponse.model';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  propertyId = 0;
  stockModel: StockDataModel;
  baseResponseModel: BaseResponseModel;
  loaded = false;
  constructor(private route: ActivatedRoute, private stockService: StockService) {
    this.propertyId = +this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.stockService.getStockDataById(this.propertyId).subscribe(data => {
      this.stockModel = data;
      this.loaded = true;
    });
  }
  saveProperty(id, city, state): void {
    Swal.fire({
      title: 'Do you want to save this property?',
      text: `The property ${id} - ${city} - ${state} will be saved.`,
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Save!',
      cancelButtonText: 'Cancel',
    }).then((value) => {
      if (value.isConfirmed) {
        this.loaded = false;
        this.stockService.saveStockDataById(id).subscribe(data => {
          this.baseResponseModel = data;
          this.loaded = true;
          const modalTitle = this.baseResponseModel.isSuccess ? 'Cool!' : 'Something went wrong';
          Swal.fire({
            title: modalTitle,
            text: this.baseResponseModel.message,
            icon: this.baseResponseModel.isSuccess ? 'success' : 'error',
            confirmButtonText: 'Okay!',
          });
        });
      }
    });
  }

}
