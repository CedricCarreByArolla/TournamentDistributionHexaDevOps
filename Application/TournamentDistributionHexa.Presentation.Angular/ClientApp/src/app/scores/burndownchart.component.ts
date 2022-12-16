import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBurndownchartLine } from './IBurndownchartLine';

@Component({
  selector: 'burndownchart',
  templateUrl: './burndownchart.component.html',
  styleUrls: ['./burndownchart.component.css']
})
export class BurndownchartComponent implements OnInit {
  @Input() tournamentId: number = 0;
  private burndownChartLines: IBurndownchartLine[] = [];

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.http.get<IBurndownchartLine[]>('https://localhost:7250/Matchs/BurndownChartLines/' + this.tournamentId).subscribe(result => {
      this.burndownChartLines = result;
    }, error => console.error(error));

  }
  getBurndownChartLines(): IBurndownchartLine[] {
    return this.burndownChartLines;
  }
}
