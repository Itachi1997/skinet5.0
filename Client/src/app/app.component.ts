import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './Models/Pagination';
import { IProduct } from './Models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[] = [];

  constructor(private httpclient: HttpClient) { }

  ngOnInit(): void {
    this.httpclient.get("https://localhost:5001/api/products?pageSize=50").subscribe({
      next: (res: IPagination) => {
        this.products = res.data;
      },
      error: (err) => {
        console.log(err);
      }
    })
    // ((res: IPagination) => {
    //   this.products = res.data;
    // }
    // , err => {
    //   console.log(err);
    // }
    // );
  }
}
