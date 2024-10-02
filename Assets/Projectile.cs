using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float vitesse = 10f; // Vitesse du projectile

    void Update()
    {
        D�placerProjectile();
    }

    void D�placerProjectile()
    {
        // Le projectile se d�place vers le haut de l'�cran
        transform.Translate(Vector3.up * vitesse * Time.deltaTime);

        // D�truire le projectile s'il sort de l'�cran
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // Le projectile est d�truit automatiquement lors d'une collision avec un ennemi (g�r� dans le script Ennemi)
}
