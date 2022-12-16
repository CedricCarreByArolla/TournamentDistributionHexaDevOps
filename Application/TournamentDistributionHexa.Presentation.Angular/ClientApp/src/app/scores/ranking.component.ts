import { Component, Input, OnInit } from '@angular/core';
import { IRank } from './IRank';
import { IScore } from './IScore';

@Component({
  selector: 'ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css']
})
export class RankingComponent implements OnInit {
  @Input() tournamentId: number = 0;
  public classements: IRank[] = [];
  public nbMatchFinis: number = 0;
  public nbMatchs: number = 0;
  public progressionTournoi: number = 0;
  @Input()
    scores: IScore[] = [];

  ngOnInit(): void {
    this.nbMatchFinis = this.scores.filter(function (score) {
      return score.match.endDate != null;
    }).length;
    this.nbMatchs = this.scores.length;
    this.progressionTournoi = this.nbMatchFinis * 100 / this.nbMatchs;

  }
}
