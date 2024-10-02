using UnityEngine;
using UnityEngine.UI;

public class ClassementManager : MonoBehaviour
{
    public Text classementText; // Texte qui affichera les meilleurs scores
    public int nombreDeScores = 5; // Nombre de scores à afficher
    private int[] meilleursScores;

    void Start()
    {
        meilleursScores = new int[nombreDeScores];
        ChargerClassement();
        MettreAJourAffichageClassement();
    }

    // Méthode pour ajouter un score dans le classement
    public void AjouterScore(int score)
    {
        for (int i = 0; i < nombreDeScores; i++)
        {
            if (score > meilleursScores[i])
            {
                // Décale les scores plus bas
                for (int j = nombreDeScores - 1; j > i; j--)
                {
                    meilleursScores[j] = meilleursScores[j - 1];
                }
                meilleursScores[i] = score;
                SauvegarderClassement();
                MettreAJourAffichageClassement();
                break;
            }
        }
    }

    // Sauvegarder le classement dans les PlayerPrefs (système de stockage local)
    void SauvegarderClassement()
    {
        for (int i = 0; i < nombreDeScores; i++)
        {
            PlayerPrefs.SetInt("Score" + i, meilleursScores[i]);
        }
    }

    // Charger le classement depuis les PlayerPrefs
    void ChargerClassement()
    {
        for (int i = 0; i < nombreDeScores; i++)
        {
            meilleursScores[i] = PlayerPrefs.GetInt("Score" + i, 0);
        }
    }

    // Mettre à jour l'affichage du classement
    void MettreAJourAffichageClassement()
    {
        classementText.text = "Classement :\n";
        for (int i = 0; i < nombreDeScores; i++)
        {
            classementText.text += (i + 1) + ". " + meilleursScores[i] + "\n";
        }
    }
}
