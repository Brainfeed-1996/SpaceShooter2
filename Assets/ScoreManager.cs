using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Score actuel
    public Text scoreText; // UI pour afficher le score

    void Start()
    {
        // Mise à jour initiale de l'affichage du score
        MettreAJourScore();
    }

    // Méthode pour ajouter des points au score
    public void AjouterPoints(int points)
    {
        score += points;
        MettreAJourScore();
    }

    // Méthode pour mettre à jour l'affichage du score
    void MettreAJourScore()
    {
        scoreText.text = "Score : " + score;
    }
}
