import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: ['./tournaments.component.css']
})
export class TournamentsComponent implements OnInit {

  private _http: HttpClient | undefined;
  public tournaments: ITournament[] = [];

  constructor(http: HttpClient) {
    this._http = http;
  }
  ngOnInit(): void {
    this._http?.get<ITournament[]>('https://localhost:7250/tournaments/').subscribe(result => {
      this.tournaments = result;
    }, error => console.error(error));
  }
}
interface ITournament {
  id: number;
  name: string;
  startDate: Date;
  endDate: Date;
}
