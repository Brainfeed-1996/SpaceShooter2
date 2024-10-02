using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de d�placement de l'ennemi
    public int pointsDeVie = 1; // Points de vie de l'ennemi

    void Update()
    {
        D�placerEnnemi();
    }

    void D�placerEnnemi()
    {
        // D�placement de l'ennemi vers le bas de l'�cran
        transform.Translate(Vector3.down * vitesse * Time.deltaTime);

        // D�truire l'ennemi s'il sort de l'�cran
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Gestion des collisions avec les projectiles
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            PrendreDesD�g�ts(1); // Chaque projectile inflige 1 point de d�g�t
            Destroy(collision.gameObject); // D�truire le projectile
        }
    }
    public AudioSource effetSonoreExplosion; // Ajoutez une AudioSource dans l'inspecteur de Unity pour les sons d'explosion

    void DetruireEnnemi()
    {
        // Ajoute 100 points au score lorsqu'un ennemi est d�truit
        FindObjectOfType<ScoreManager>().AjouterPoints(100);
        effetSonoreExplosion.Play(); // Joue le son d'explosion
        Destroy(gameObject); // D�truit l'ennemi
    }
    Animator animator; // R�f�rence � l'Animator de l'ennemi

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtenez la r�f�rence de l'Animator
    }

    void PrendreDesD�g�ts(int d�g�ts)
    {
        pointsDeVie -= d�g�ts;
        animator.SetTrigger("Touch�"); // D�clenche l'animation de "Touch�"
        if (pointsDeVie <= 0)
        {
            DetruireEnnemi();
        }
    }



}
