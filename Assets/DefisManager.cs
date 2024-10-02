using UnityEngine;
using UnityEngine.UI;
using System;

public class DéfisManager : MonoBehaviour
{
    public Text défiText; // Texte pour afficher le défi du jour
    public int récompenseGemmes = 100; // Récompense pour avoir réussi le défi
    private string défiActuel;

    void Start()
    {
        GénérerDéfi();
        MettreAJourAffichageDéfi();
    }

    // Génère un défi quotidien basé sur la date actuelle
    void GénérerDéfi()
    {
        DateTime aujourdhui = DateTime.Now;
        int jour = aujourdhui.Day;
        défiActuel = "Détruire " + (jour * 2) + " ennemis en une seule partie.";
    }

    // Vérifie si le défi est accompli
    public void VérifierDéfi(int ennemisDétruits)
    {
        int objectif = DateTime.Now.Day * 2;
        if (ennemisDétruits >= objectif)
        {
            RécompenserJoueur();
        }
    }

    // Récompense le joueur pour avoir terminé le défi
    void RécompenserJoueur()
    {
        FindObjectOfType<GemmesManager>().AjouterGemmes(récompenseGemmes);
        Debug.Log("Défi accompli ! Vous avez gagné " + récompenseGemmes + " gemmes !");
    }

    // Met à jour l'affichage du défi
    void MettreAJourAffichageDéfi()
    {
        défiText.text = "Défi du jour : " + défiActuel;
    }
}
