using UnityEngine;
using UnityEngine.UI;

public class SystèmeDeRécompenses : MonoBehaviour
{
    public GemmesManager gemmesManager; // Référence au gestionnaire de gemmes
    public Button boutonAméliorationVie; // Bouton pour acheter des points de vie supplémentaires
    public Button boutonAméliorationTir; // Bouton pour améliorer les tirs

    void Start()
    {
        boutonAméliorationVie.onClick.AddListener(AcheterAméliorationVie);
        boutonAméliorationTir.onClick.AddListener(AcheterAméliorationTir);
    }

    public void OuvrirBoutique()
    {
        // Affiche la boutique (panneau UI) quand le joueur accède à l'écran de boutique
    }

    void AcheterAméliorationVie()
    {
        if (gemmesManager.gemmes >= 100)
        {
            gemmesManager.UtiliserGemmes(100);
            VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
            vaisseau.pointsDeVie += 1;
            Debug.Log("Amélioration : +1 point de vie !");
        }
        else
        {
            Debug.Log("Pas assez de gemmes pour acheter cette amélioration.");
        }
    }

    void AcheterAméliorationTir()
    {
        if (gemmesManager.gemmes >= 150)
        {
            gemmesManager.UtiliserGemmes(150);
            VaisseauSpatial vaisseau = FindObjectOfType<VaisseauSpatial>();
            vaisseau.tempsEntreTirs -= 0.1f; // Tirs plus rapides
            Debug.Log("Amélioration : Tirs plus rapides !");
        }
        else
        {
            Debug.Log("Pas assez de gemmes pour acheter cette amélioration.");
        }
    }
}
