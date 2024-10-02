using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject écranGameOver; // Le panneau ou écran de Game Over

    public void AfficherGameOver()
    {
        écranGameOver.SetActive(true); // Active l'écran de Game Over
        Time.timeScale = 0f; // Met le jeu en pause
    }

    public void Rejouer()
    {
        Time.timeScale = 1f; // Reprend le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recharge le niveau actuel
    }

    public void RetourAuMenu()
    {
        Time.timeScale = 1f; // Reprend le jeu
        SceneManager.LoadScene("MenuPrincipal"); // Charge la scène du menu principal
    }
}
