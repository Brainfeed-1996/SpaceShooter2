using UnityEngine;
using UnityEngine.UI;

public class Syst�meDeR�compenses : MonoBehaviour
{
    public GemmesManager gemmesManager; // R�f�rence au gestionnaire de gemmes
    public Button boutonAm�liorationVie; // Bouton pour acheter des points de vie suppl�mentaires
    public Button boutonAm�liorationTir; // Bouton pour am�liorer les tirs

    void Start()
    {
        boutonAm�liorationVie.onClick.AddListener(AcheterAm�liorationVie);
        boutonAm�liorationTir.onClick.AddListener(AcheterAm�liorationTir);
    }

    public void OuvrirBoutique()
    {
        // Affiche la boutique (panneau UI) quand le joueur acc�de � l'�cran de boutique
    }

    void AcheterAm�liorationVie()
    {
        if (gemmesManager.gemmes >= 100)
        {
            gemmesManager.UtiliserGemmes(100);
            VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
            vaisseau.pointsDeVie += 1;
            Debug.Log("Am�lioration : +1 point de vie !");
        }
        else
        {
            Debug.Log("Pas assez de gemmes pour acheter cette am�lioration.");
        }
    }

    void AcheterAm�liorationTir()
    {
        if (gemmesManager.gemmes >= 150)
        {
            gemmesManager.UtiliserGemmes(150);
            VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
            vaisseau.tempsEntreTirs -= 0.1f; // Tirs plus rapides
            Debug.Log("Am�lioration : Tirs plus rapides !");
        }
        else
        {
            Debug.Log("Pas assez de gemmes pour acheter cette am�lioration.");
        }
    }
}
