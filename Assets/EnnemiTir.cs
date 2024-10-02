using UnityEngine;

public class EnnemiTir : MonoBehaviour
{
    public float vitesse = 3f; // Vitesse de d�placement de l'ennemi
    public GameObject projectileEnnemi; // Projectile tir� par l'ennemi
    public Transform pointDeTir; // Point d'o� les projectiles sont tir�s
    public float tempsEntreTirs = 2f; // D�lai entre chaque tir
    private float tempsRestantPourTirer = 0f;

    void Update()
    {
        D�placerEnnemi();
        G�rerLesTirs();
    }

    void D�placerEnnemi()
    {
        transform.Translate(Vector3.down * vitesse * Time.deltaTime);

        // D�truire l'ennemi s'il sort de l'�cran
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void G�rerLesTirs()
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

    // D�tection des collisions avec les projectiles du joueur (similaire aux autres ennemis)
}
