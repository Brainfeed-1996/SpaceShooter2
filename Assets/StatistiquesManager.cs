using UnityEngine;
using UnityEngine.UI;

public class StatistiquesManager : MonoBehaviour
{
    public Text ennemisD�truitsText;
    public Text niveauxAtteintsText;
    public Text gemmesCollect�esText;

    private int ennemisD�truits = 0;
    private int niveauxAtteints = 0;
    private int gemmesCollect�es = 0;

    void Start()
    {
        MettreAJourStatistiques();
    }

    // Appel�e lorsqu'un ennemi est d�truit
    public void AjouterEnnemiD�truit()
    {
        ennemisD�truits++;
        MettreAJourStatistiques();
    }

    // Appel�e lorsqu'un niveau est termin�
    public void AjouterNiveauAtteint()
    {
        niveauxAtteints++;
        MettreAJourStatistiques();
    }

    // Appel�e lorsqu'un joueur ramasse des gemmes
    public void AjouterGemmes(int quantit�)
    {
        gemmesCollect�es += quantit�;
        MettreAJourStatistiques();
    }

    // Met � jour les informations � afficher
    void MettreAJourStatistiques()
    {
        ennemisD�truitsText.text = "Ennemis d�truits : " + ennemisD�truits;
        niveauxAtteintsText.text = "Niveaux atteints : " + niveauxAtteints;
        gemmesCollect�esText.text = "Gemmes collect�es : " + gemmesCollect�es;
    }
}
