using UnityEngine;

public class EnnemiTir : MonoBehaviour
{
    public float vitesse = 3f; // Vitesse de déplacement de l'ennemi
    public GameObject projectileEnnemi; // Projectile tiré par l'ennemi
    public Transform pointDeTir; // Point d'où les projectiles sont tirés
    public float tempsEntreTirs = 2f; // Délai entre chaque tir
    private float tempsRestantPourTirer = 0f;

    void Update()
    {
        DéplacerEnnemi();
        GérerLesTirs();
    }

    void DéplacerEnnemi()
    {
        transform.Translate(Vector3.down * vitesse * Time.deltaTime);

        // Détruire l'ennemi s'il sort de l'écran
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void GérerLesTirs()
    {
        tempsRestantPourTirer -= Time.deltaTime;

        if (tempsRestantPourTirer <= 0f)
        {
            TirerProjectile();
            tempsRestantPourTirer = tempsEntreTirs;
        }
    }

    void TirerProjectile()
    {
        Instantiate(projectileEnnemi, pointDeTir.position, pointDeTir.rotation);
    }

    // Détection des collisions avec les projectiles du joueur (similaire aux autres ennemis)
}
