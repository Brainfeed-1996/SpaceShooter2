using UnityEngine;

public class ModeInfiniManager : MonoBehaviour
{
    public int vagueActuelle = 1;
    public GameObject ennemiPrefab;
    public Transform[] pointsDeSpawn;

    void Start()
    {
        LancerVague();
    }

    // Lancer une vague d'ennemis
    void LancerVague()
    {
        for (int i = 0; i < vagueActuelle * 3; i++) // Augmente le nombre d'ennemis par vague
        {
            int indexSpawn = Random.Range(0, pointsDeSpawn.Length);
            Instantiate(ennemiPrefab, pointsDeSpawn[indexSpawn].position, Quaternion.identity);
        }
        vagueActuelle++;
    }

    // Appelée lorsque tous les ennemis sont détruits
    void VérifierFinDeVague()
    {
        if (GameObject.FindGameObjectsWithTag("Ennemi").Length == 0)
        {
            LancerVague();
        }
    }
}
