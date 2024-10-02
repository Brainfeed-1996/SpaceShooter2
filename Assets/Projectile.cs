using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float vitesse = 10f; // Vitesse du projectile

    void Update()
    {
        DéplacerProjectile();
    }

    void DéplacerProjectile()
    {
        // Le projectile se déplace vers le haut de l'écran
        transform.Translate(Vector3.up * vitesse * Time.deltaTime);

        // Détruire le projectile s'il sort de l'écran
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // Le projectile est détruit automatiquement lors d'une collision avec un ennemi (géré dans le script Ennemi)
}
