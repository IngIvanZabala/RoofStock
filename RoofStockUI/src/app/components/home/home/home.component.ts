import { Component, OnInit } from '@angular/core';
import { StockDataModel } from 'src/app/Models/stockData.model';
import { StockService } from '../../../services/stock.service';
import { RouterModule } from '@angular/router';
import { SpinnerComponent } from '../../shared/spinner/spinner.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  stockModel: StockDataModel[];
  loaded = false;
  constructor(
    private stockService: StockService
  ) { }

  ngOnInit(): void {
    this.stockService.getStockData().subscribe(data => {
      this.stockModel = data;
      this.loaded = true;
    });
  }

}
