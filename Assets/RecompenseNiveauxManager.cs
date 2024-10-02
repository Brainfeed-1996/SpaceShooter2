using UnityEngine;

public class RécompensesNiveauManager : MonoBehaviour
{
    public int gemmesParNiveau = 50; // Nombre de gemmes gagnées à la fin d'un niveau
    public int améliorationVieParNiveau = 1; // Amélioration des points de vie après chaque niveau

    // Méthode appelée à la fin d'un niveau
    public void RécompenserJoueur()
    {
        // Ajoute des gemmes
        FindObjectOfType<GemmesManager>().AjouterGemmes(gemmesParNiveau);
        // Améliore les points de vie du joueur
        VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
        vaisseau.pointsDeVie += améliorationVieParNiveau;
        Debug.Log("Niveau terminé ! Vous avez gagné " + gemmesParNiveau + " gemmes et " + améliorationVieParNiveau + " point(s) de vie.");
    }
}
