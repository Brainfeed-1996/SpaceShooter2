using UnityEngine;

public class BossUnique : MonoBehaviour
{
    public float vitesse = 2f; // Vitesse de déplacement du boss
    public int pointsDeVie = 50; // Points de vie du boss
    public GameObject projectileBoss; // Projectile du boss
    public Transform[] pointsDeTir; // Points multiples de tir pour le boss
    public float tempsEntreTirs = 1.5f;
    private float tempsRestantPourTirer = 0f;
    public float mouvementAmplitude = 3f; // Amplitude du mouvement gauche-droite

    void Update()
    {
        DéplacerBoss();
        GérerLesTirs();
    }

    void DéplacerBoss()
    {
        // Mouvement oscillant gauche-droite
        transform.Translate(Vector3.right * Mathf.Sin(Time.time * vitesse) * mouvementAmplitude * Time.deltaTime);
    }

    void GérerLesTirs()
    {
        tempsRestantPourTirer -= Time.deltaTime;

        if (tempsRestantPourTirer <= 0f)
        {
            TirerProjectiles();
            tempsRestantPourTirer = tempsEntreTirs;
        }
    }

    void TirerProjectiles()
    {
        // Tire à partir de plusieurs points de tir
        foreach (Transform point in pointsDeTir)
        {
            Instantiate(projectileBoss, point.position, point.rotation);
        }
    }

    void PrendreDesDégâts(int dégâts)
    {
        pointsDeVie -= dégâts;
        if (pointsDeVie <= 0)
        {
            DetruireBoss();
        }
    }

    void DetruireBoss()
    {
        // Explosion et autres effets à ajouter ici
        Destroy(gameObject);
        Debug.Log("Le boss a été détruit !");
    }
}
