using UnityEngine;

public class GemmesManager : MonoBehaviour
{
    public int gemmes = 0; // Nombre de gemmes collectées

    public void AjouterGemmes(int quantité)
    {
        gemmes += quantité;
    }

    public void UtiliserGemmes(int quantité)
    {
        if (gemmes >= quantité)
        {
            gemmes -= quantité;
            // Action à effectuer, par exemple ressusciter le joueur
        }
        else
        {
            Debug.Log("Pas assez de gemmes !");
        }
    }

    // Exemple d'utilisation lors de la mort du joueur
    public void RessusciterJoueur()
    {
        if (gemmes >= 100) // Ressusciter coûte 100 gemmes
        {
            UtiliserGemmes(100);
            // Logique de ressuscitation ici
            Debug.Log("Le joueur est ressuscité !");
        }
    }
}
