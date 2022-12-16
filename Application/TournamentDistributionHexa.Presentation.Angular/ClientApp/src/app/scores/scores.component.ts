import { Component, OnDestroy, OnInit } from '@angular/core';
import { from, groupBy, mergeMap, Observable, of, Subscription, toArray, zip } from 'rxjs';
import { IScore } from './IScore';
import { ScoreService } from './scores.service';

@Component({
  selector: 'scores',
  templateUrl: './scores.component.html',
  styleUrls: ['./scores.component.css'],
  providers: [ScoreService]
})
export class ScoresComponent implements OnInit, OnDestroy {

  private subscription!: Subscription;
  public scoresGroupByGames!: [string, IScore[]];
  public scores: IScore[] = [];
  public scoresObservable!: Observable<IScore[]>;

  constructor(private scoreService: ScoreService) {
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    }
  ngOnInit(): void {
    this.scoresObservable = this.scoreService.getScores();
    this.subscription = this.scoresObservable.subscribe({
      next: scores => {
        this.scores = scores;
        from(scores)
          .pipe(
            groupBy(
              score => score.game.name,
              s => s
            ),
            mergeMap(group => zip(of(group.key), group.pipe(toArray())))
          )
          .subscribe({
            next: scoresGrouped => {
              this.scoresGroupByGames = scoresGrouped;
            }
          });
      }
    });
  }
}
