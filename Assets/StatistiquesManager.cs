using UnityEngine;
using UnityEngine.UI;

public class StatistiquesManager : MonoBehaviour
{
    public Text ennemisDétruitsText;
    public Text niveauxAtteintsText;
    public Text gemmesCollectéesText;

    private int ennemisDétruits = 0;
    private int niveauxAtteints = 0;
    private int gemmesCollectées = 0;

    void Start()
    {
        MettreAJourStatistiques();
    }

    // Appelée lorsqu'un ennemi est détruit
    public void AjouterEnnemiDétruit()
    {
        ennemisDétruits++;
        MettreAJourStatistiques();
    }

    // Appelée lorsqu'un niveau est terminé
    public void AjouterNiveauAtteint()
    {
        niveauxAtteints++;
        MettreAJourStatistiques();
    }

    // Appelée lorsqu'un joueur ramasse des gemmes
    public void AjouterGemmes(int quantité)
    {
        gemmesCollectées += quantité;
        MettreAJourStatistiques();
    }

    // Met à jour les informations à afficher
    void MettreAJourStatistiques()
    {
        ennemisDétruitsText.text = "Ennemis détruits : " + ennemisDétruits;
        niveauxAtteintsText.text = "Niveaux atteints : " + niveauxAtteints;
        gemmesCollectéesText.text = "Gemmes collectées : " + gemmesCollectées;
    }
}
