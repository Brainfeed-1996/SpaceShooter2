using UnityEngine;
using UnityEngine.UI;

public class Qu�tesSecondairesManager : MonoBehaviour
{
    public Text queteText; // Texte pour afficher la qu�te actuelle
    private string queteActuelle;
    private bool qu�teAccomplie = false;
    private int nombreEnnemisD�truits = 0;

    public int objectifEnnemis = 20; // Objectif par d�faut pour d�truire des ennemis
    public int r�compenseGemmes = 100; // R�compense pour avoir termin� la qu�te

    void Start()
    {
        G�n�rerQu�te();
        MettreAJourAffichageQu�te();
    }

    // G�n�re une qu�te al�atoire
    void G�n�rerQu�te()
    {
        queteActuelle = "D�truire " + objectifEnnemis + " ennemis sans se faire toucher.";
    }

    // Appel�e chaque fois qu'un ennemi est d�truit
    public void AjouterEnnemiD�truit()
    {
        nombreEnnemisD�truits++;
        V�rifierQu�te();
    }

    // V�rifie si la qu�te est accomplie
    void V�rifierQu�te()
    {
        if (nombreEnnemisD�truits >= objectifEnnemis && !qu�teAccomplie)
        {
            qu�teAccomplie = true;
            R�compenserJoueur();
        }
    }

    // R�compense le joueur pour avoir termin� la qu�te
    void R�compenserJoueur()
    {
        FindObjectOfType<GemmesManager>().AjouterGemmes(r�compenseGemmes);
        Debug.Log("Qu�te accomplie ! Vous avez gagn� " + r�compenseGemmes + " gemmes.");
        queteText.text = "Qu�te accomplie !";
    }

    // Met � jour l'affichage de la qu�te
    void MettreAJourAffichageQu�te()
    {
        queteText.text = "Qu�te : " + queteActuelle;
    }
}
