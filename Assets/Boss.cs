using UnityEngine;

public class Boss : MonoBehaviour
{
    public float vitesse = 2f; // Vitesse de d�placement du boss
    public int pointsDeVie = 20; // Points de vie du boss
    public GameObject projectileBoss; // Projectile sp�cial du boss
    public Transform[] pointsDeTir; // Points multiples de tir
    public float tempsEntreTirs = 1f; // D�lai entre chaque tir
    private float tempsRestantPourTirer = 0f;

    void Update()
    {
        D�placerBoss();
        G�rerLesTirs();
    }

    void D�placerBoss()
    {
        // Le boss se d�place de gauche � droite de fa�on cyclique
        transform.Translate(Vector3.right * Mathf.Sin(Time.time * vitesse) * Time.deltaTime);
    }

    void G�rerLesTirs()
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
        // Tir � partir de plusieurs points
        foreach (Transform point in pointsDeTir)
        {
            Instantiate(projectileBoss, point.position, point.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            PrendreDesD�g�ts(1); // Chaque projectile du joueur inflige 1 point de d�g�t
            Destroy(collision.gameObject); // D�truire le projectile apr�s l'impact
        }
    }

    void PrendreDesD�g�ts(int d�g�ts)
    {
        pointsDeVie -= d�g�ts;
        if (pointsDeVie <= 0)
        {
            DetruireBoss();
        }
    }

    void DetruireBoss()
    {
        // Logique de destruction du boss (par exemple, explosion, transition au niveau suivant)
        FindObjectOfType<ScoreManager>().AjouterPoints(1000); // Le boss rapporte plus de points
        Destroy(gameObject); // D�truit le boss
    }

}
