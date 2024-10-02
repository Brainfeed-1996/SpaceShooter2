using UnityEngine;
using UnityEngine.UI;

public class SkinsVaisseauManager : MonoBehaviour
{
    public Sprite[] skinsVaisseaux; // Différents skins disponibles pour le vaisseau
    public Image vaisseauPreview; // Prévisualisation du skin dans le menu
    public int skinActuel = 0; // Index du skin actuellement sélectionné
    public int coûtDéblocage = 200; // Coût en gemmes pour débloquer un nouveau skin

    public Button boutonDébloquer; // Bouton pour débloquer un nouveau skin
    public GemmesManager gemmesManager; // Référence pour la gestion des gemmes

    private bool[] skinsDébloqués; // Liste des skins débloqués

    void Start()
    {
        skinsDébloqués = new bool[skinsVaisseaux.Length];
        MettreAJourPrévisualisation();
    }

    // Méthode pour afficher le skin suivant
    public void SkinSuivant()
    {
        skinActuel = (skinActuel + 1) % skinsVaisseaux.Length;
        MettreAJourPrévisualisation();
    }

    // Méthode pour afficher le skin précédent
    public void SkinPrécédent()
    {
        skinActuel--;
        if (skinActuel < 0)
        {
            skinActuel = skinsVaisseaux.Length - 1;
        }
        MettreAJourPrévisualisation();
    }

    // Méthode pour débloquer un skin
    public void DébloquerSkin()
    {
        if (!skinsDébloqués[skinActuel] && gemmesManager.gemmes >= coûtDéblocage)
        {
            skinsDébloqués[skinActuel] = true;
            gemmesManager.UtiliserGemmes(coûtDéblocage);
            Debug.Log("Skin débloqué !");
            MettreAJourPrévisualisation();
        }
        else
        {
            Debug.Log("Pas assez de gemmes ou skin déjà débloqué.");
        }
    }

    // Applique le skin au vaisseau lors du démarrage de la partie
    public void AppliquerSkin(SpriteRenderer vaisseau)
    {
        vaisseau.sprite = skinsVaisseaux[skinActuel];
    }

    // Met à jour la prévisualisation dans le menu
    void MettreAJourPrévisualisation()
    {
        vaisseauPreview.sprite = skinsVaisseaux[skinActuel];
        boutonDébloquer.interactable = !skinsDébloqués[skinActuel]; // Désactiver le bouton si le skin est déjà débloqué
    }
}
