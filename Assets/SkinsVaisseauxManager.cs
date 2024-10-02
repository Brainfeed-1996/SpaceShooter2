using UnityEngine;
using UnityEngine.UI;

public class SkinsVaisseauManager : MonoBehaviour
{
    public Sprite[] skinsVaisseaux; // Diff�rents skins disponibles pour le vaisseau
    public Image vaisseauPreview; // Pr�visualisation du skin dans le menu
    public int skinActuel = 0; // Index du skin actuellement s�lectionn�
    public int co�tD�blocage = 200; // Co�t en gemmes pour d�bloquer un nouveau skin

    public Button boutonD�bloquer; // Bouton pour d�bloquer un nouveau skin
    public GemmesManager gemmesManager; // R�f�rence pour la gestion des gemmes

    private bool[] skinsD�bloqu�s; // Liste des skins d�bloqu�s

    void Start()
    {
        skinsD�bloqu�s = new bool[skinsVaisseaux.Length];
        MettreAJourPr�visualisation();
    }

    // M�thode pour afficher le skin suivant
    public void SkinSuivant()
    {
        skinActuel = (skinActuel + 1) % skinsVaisseaux.Length;
        MettreAJourPr�visualisation();
    }

    // M�thode pour afficher le skin pr�c�dent
    public void SkinPr�c�dent()
    {
        skinActuel--;
        if (skinActuel < 0)
        {
            skinActuel = skinsVaisseaux.Length - 1;
        }
        MettreAJourPr�visualisation();
    }

    // M�thode pour d�bloquer un skin
    public void D�bloquerSkin()
    {
        if (!skinsD�bloqu�s[skinActuel] && gemmesManager.gemmes >= co�tD�blocage)
        {
            skinsD�bloqu�s[skinActuel] = true;
            gemmesManager.UtiliserGemmes(co�tD�blocage);
            Debug.Log("Skin d�bloqu� !");
            MettreAJourPr�visualisation();
        }
        else
        {
            Debug.Log("Pas assez de gemmes ou skin d�j� d�bloqu�.");
        }
    }

    // Applique le skin au vaisseau lors du d�marrage de la partie
    public void AppliquerSkin(SpriteRenderer vaisseau)
    {
        vaisseau.sprite = skinsVaisseaux[skinActuel];
    }

    // Met � jour la pr�visualisation dans le menu
    void MettreAJourPr�visualisation()
    {
        vaisseauPreview.sprite = skinsVaisseaux[skinActuel];
        boutonD�bloquer.interactable = !skinsD�bloqu�s[skinActuel]; // D�sactiver le bouton si le skin est d�j� d�bloqu�
    }
}
