using UnityEngine;

public class GestionDesNiveaux : MonoBehaviour
{
    public GameObject ennemiPrefab;
    public Transform[] pointsDeSpawn;
    public int nombreEnnemisDeBase = 5;
    public float intervalleApparition = 1f;
    public float vitesseEnnemi = 2f;
    public int niveauActuel = 1;

    void Start()
    {
        CommencerNiveau();
    }

    public void CommencerNiveau()
    {
        for (int i = 0; i < nombreEnnemisDeBase + (niveauActuel * 2); i++) // Augmente le nombre d'ennemis par niveau
        {
            int indexSpawn = Random.Range(0, pointsDeSpawn.Length);
            GameObject ennemi = Instantiate(ennemiPrefab, pointsDeSpawn[indexSpawn].position, Quaternion.identity);
            ennemi.GetComponent<Ennemi>().vitesse = vitesseEnnemi + (niveauActuel * 0.5f); // Augmente la vitesse des ennemis
        }
        niveauActuel++;
    }

    // Méthode appelée après avoir détruit tous les ennemis
    public void VérifierFinDeNiveau()
    {
        if (GameObject.FindGameObjectsWithTag("Ennemi").Length == 0)
        {
            CommencerNiveau(); // Passe au niveau suivant
        }
    }
}
