select m.id,j.nom,m.nom,jo.id, jo.Nom, jo.prenom
from Composition c
inner join match m on c.MatchId = m.Id
inner join score s on s.MatchId = m.Id
inner join jeu j on j.Id = c.JeuId
inner join Joueur jo on jo.Id = s.JoueurId
