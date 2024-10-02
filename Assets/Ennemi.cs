using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de déplacement de l'ennemi
    public int pointsDeVie = 1; // Points de vie de l'ennemi

    void Update()
    {
        DéplacerEnnemi();
    }

    void DéplacerEnnemi()
    {
        // Déplacement de l'ennemi vers le bas de l'écran
        transform.Translate(Vector3.down * vitesse * Time.deltaTime);

        // Détruire l'ennemi s'il sort de l'écran
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
            PrendreDesDégâts(1); // Chaque projectile inflige 1 point de dégât
            Destroy(collision.gameObject); // Détruire le projectile
        }
    }
    public AudioSource effetSonoreExplosion; // Ajoutez une AudioSource dans l'inspecteur de Unity pour les sons d'explosion

    void DetruireEnnemi()
    {
        // Ajoute 100 points au score lorsqu'un ennemi est détruit
        FindObjectOfType<ScoreManager>().AjouterPoints(100);
        effetSonoreExplosion.Play(); // Joue le son d'explosion
        Destroy(gameObject); // Détruit l'ennemi
    }
    Animator animator; // Référence à l'Animator de l'ennemi

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtenez la référence de l'Animator
    }

    void PrendreDesDégâts(int dégâts)
    {
        pointsDeVie -= dégâts;
        animator.SetTrigger("Touché"); // Déclenche l'animation de "Touché"
        if (pointsDeVie <= 0)
        {
            DetruireEnnemi();
        }
    }



}
