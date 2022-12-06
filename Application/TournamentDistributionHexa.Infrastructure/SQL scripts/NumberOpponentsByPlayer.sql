
Select
    p.ID, p.prenom, p.Nom, p.telephone, COUNT(DISTINCT so.JoueurId) count
from 
    Joueur p
    JOIN Score s ON p.Id = s.JoueurId
    JOIN Score so On so.MatchId = s.MatchId and so.JoueurId != p.Id
	join Composition c on c.MatchId = so.MatchId and c.TournoiId = 7
Group by p.ID,p.prenom,p.Nom,p.telephone