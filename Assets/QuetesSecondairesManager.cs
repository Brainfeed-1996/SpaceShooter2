using UnityEngine;
using UnityEngine.UI;

public class QuêtesSecondairesManager : MonoBehaviour
{
    public Text queteText; // Texte pour afficher la quête actuelle
    private string queteActuelle;
    private bool quêteAccomplie = false;
    private int nombreEnnemisDétruits = 0;

    public int objectifEnnemis = 20; // Objectif par défaut pour détruire des ennemis
    public int récompenseGemmes = 100; // Récompense pour avoir terminé la quête

    void Start()
    {
        GénérerQuête();
        MettreAJourAffichageQuête();
    }

    // Génère une quête aléatoire
    void GénérerQuête()
    {
        queteActuelle = "Détruire " + objectifEnnemis + " ennemis sans se faire toucher.";
    }

    // Appelée chaque fois qu'un ennemi est détruit
    public void AjouterEnnemiDétruit()
    {
        nombreEnnemisDétruits++;
        VérifierQuête();
    }

    // Vérifie si la quête est accomplie
    void VérifierQuête()
    {
        if (nombreEnnemisDétruits >= objectifEnnemis && !quêteAccomplie)
        {
            quêteAccomplie = true;
            RécompenserJoueur();
        }
    }

    // Récompense le joueur pour avoir terminé la quête
    void RécompenserJoueur()
    {
        FindObjectOfType<GemmesManager>().AjouterGemmes(récompenseGemmes);
        Debug.Log("Quête accomplie ! Vous avez gagné " + récompenseGemmes + " gemmes.");
        queteText.text = "Quête accomplie !";
    }

    // Met à jour l'affichage de la quête
    void MettreAJourAffichageQuête()
    {
        queteText.text = "Quête : " + queteActuelle;
    }
}
