using UnityEngine;
using UnityEngine.UI;
using System;

public class D�fisManager : MonoBehaviour
{
    public Text d�fiText; // Texte pour afficher le d�fi du jour
    public int r�compenseGemmes = 100; // R�compense pour avoir r�ussi le d�fi
    private string d�fiActuel;

    void Start()
    {
        G�n�rerD�fi();
        MettreAJourAffichageD�fi();
    }

    // G�n�re un d�fi quotidien bas� sur la date actuelle
    void G�n�rerD�fi()
    {
        DateTime aujourdhui = DateTime.Now;
        int jour = aujourdhui.Day;
        d�fiActuel = "D�truire " + (jour * 2) + " ennemis en une seule partie.";
    }

    // V�rifie si le d�fi est accompli
    public void V�rifierD�fi(int ennemisD�truits)
    {
        int objectif = DateTime.Now.Day * 2;
        if (ennemisD�truits >= objectif)
        {
            R�compenserJoueur();
        }
    }

    // R�compense le joueur pour avoir termin� le d�fi
    void R�compenserJoueur()
    {
        FindObjectOfType<GemmesManager>().AjouterGemmes(r�compenseGemmes);
        Debug.Log("D�fi accompli ! Vous avez gagn� " + r�compenseGemmes + " gemmes !");
    }

    // Met � jour l'affichage du d�fi
    void MettreAJourAffichageD�fi()
    {
        d�fiText.text = "D�fi du jour : " + d�fiActuel;
    }
}
