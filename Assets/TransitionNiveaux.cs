using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionNiveau : MonoBehaviour
{
    public GameObject �cranTransition; // Panneau ou �cran de transition � afficher

    public void TerminerNiveau()
    {
        �cranTransition.SetActive(true); // Affiche l'�cran de transition
        Time.timeScale = 0f; // Met le jeu en pause
    }

    public void PasserAuNiveauSuivant()
    {
        Time.timeScale = 1f; // Reprend le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Charge le niveau suivant
    }
}
