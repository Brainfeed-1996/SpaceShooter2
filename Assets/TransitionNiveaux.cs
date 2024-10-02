using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionNiveau : MonoBehaviour
{
    public GameObject écranTransition; // Panneau ou écran de transition à afficher

    public void TerminerNiveau()
    {
        écranTransition.SetActive(true); // Affiche l'écran de transition
        Time.timeScale = 0f; // Met le jeu en pause
    }

    public void PasserAuNiveauSuivant()
    {
        Time.timeScale = 1f; // Reprend le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Charge le niveau suivant
    }
}
