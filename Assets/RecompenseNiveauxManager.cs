using UnityEngine;

public class R�compensesNiveauManager : MonoBehaviour
{
    public int gemmesParNiveau = 50; // Nombre de gemmes gagn�es � la fin d'un niveau
    public int am�liorationVieParNiveau = 1; // Am�lioration des points de vie apr�s chaque niveau

    // M�thode appel�e � la fin d'un niveau
    public void R�compenserJoueur()
    {
        // Ajoute des gemmes
        FindObjectOfType<GemmesManager>().AjouterGemmes(gemmesParNiveau);
        // Am�liore les points de vie du joueur
        VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
        vaisseau.pointsDeVie += am�liorationVieParNiveau;
        Debug.Log("Niveau termin� ! Vous avez gagn� " + gemmesParNiveau + " gemmes et " + am�liorationVieParNiveau + " point(s) de vie.");
    }
}
