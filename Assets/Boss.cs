using UnityEngine;

public class Boss : MonoBehaviour
{
    public float vitesse = 2f; // Vitesse de déplacement du boss
    public int pointsDeVie = 20; // Points de vie du boss
    public GameObject projectileBoss; // Projectile spécial du boss
    public Transform[] pointsDeTir; // Points multiples de tir
    public float tempsEntreTirs = 1f; // Délai entre chaque tir
    private float tempsRestantPourTirer = 0f;

    void Update()
    {
        DéplacerBoss();
        GérerLesTirs();
    }

    void DéplacerBoss()
    {
        // Le boss se déplace de gauche à droite de façon cyclique
        transform.Translate(Vector3.right * Mathf.Sin(Time.time * vitesse) * Time.deltaTime);
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
        // Tir à partir de plusieurs points
        foreach (Transform point in pointsDeTir)
        {
            Instantiate(projectileBoss, point.position, point.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            PrendreDesDégâts(1); // Chaque projectile du joueur inflige 1 point de dégât
            Destroy(collision.gameObject); // Détruire le projectile après l'impact
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
        // Logique de destruction du boss (par exemple, explosion, transition au niveau suivant)
        FindObjectOfType<ScoreManager>().AjouterPoints(1000); // Le boss rapporte plus de points
        Destroy(gameObject); // Détruit le boss
    }

}
