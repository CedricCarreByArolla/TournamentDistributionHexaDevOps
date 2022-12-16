import { IGame } from "./IGame";
import { IMatch } from "./IMatch";
import { IPlayer } from "./IPlayer";

export interface IScore {
  points: number;
  match: IMatch;
  player: IPlayer;
  game: IGame;
}
