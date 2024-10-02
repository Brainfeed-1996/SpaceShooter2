using UnityEngine;

public class GemmesManager : MonoBehaviour
{
    public int gemmes = 0; // Nombre de gemmes collect�es

    public void AjouterGemmes(int quantit�)
    {
        gemmes += quantit�;
    }

    public void UtiliserGemmes(int quantit�)
    {
        if (gemmes >= quantit�)
        {
            gemmes -= quantit�;
            // Action � effectuer, par exemple ressusciter le joueur
        }
        else
        {
            Debug.Log("Pas assez de gemmes !");
        }
    }

    // Exemple d'utilisation lors de la mort du joueur
    public void RessusciterJoueur()
    {
        if (gemmes >= 100) // Ressusciter co�te 100 gemmes
        {
            UtiliserGemmes(100);
            // Logique de ressuscitation ici
            Debug.Log("Le joueur est ressuscit� !");
        }
    }
}
