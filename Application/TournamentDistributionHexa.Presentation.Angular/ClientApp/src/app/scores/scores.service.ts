import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { IScore } from './IScore';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }
  getScores(): Observable<IScore[]> {
    return this.http.get<IScore[]>('https://localhost:7250/Tournaments/' + this.route.snapshot.paramMap.get('tournamentId') + '/Scores')
      .pipe(
        tap(data => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
    );

  }
  private handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}
