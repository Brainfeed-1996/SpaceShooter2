using UnityEngine;
using System.Collections;

public class VaisseauSpatial : MonoBehaviour
{
    public float vitesse = 10f; // Vitesse de déplacement du vaisseau
    public GameObject projectileSimple; // Projectile simple
    public GameObject projectilePuissant; // Projectile puissant
    public Transform pointDeTir; // Point de tir du projectile
    public float tempsEntreTirs = 0.5f; // Temps entre les tirs
    private float tempsRestantPourTirer = 0f; // Chrono avant le prochain tir
    public int modeDeTir = 1; // Mode de tir : 1 = simple, 2 = multiple, 3 = laser

    public bool tirPuissant = false; // Bonus de tir puissant activé ou non
    public int pointsDeVie = 3; // Points de vie du vaisseau
    public GameObject explosionPrefab; // Explosion à instancier en cas de destruction du vaisseau

    void Start()
    {
        // On s'assure que ce script ne s'applique qu'à l'objet avec le tag "Joueur"
        if (gameObject.tag != "Joueur")
        {
            Destroy(this);
        }
    }

    void Update()
    {
        DéplacerVaisseau();
        GérerLesTirs();
        ChangerModeDeTir(); // Permet de changer de mode de tir
    }

    void DéplacerVaisseau()
    {
        float mouvementHorizontal = Input.GetAxis("Horizontal");
        float mouvementVertical = Input.GetAxis("Vertical");
        Vector3 deplacement = new Vector3(mouvementHorizontal, mouvementVertical, 0f);
        transform.Translate(deplacement * vitesse * Time.deltaTime);
    }

    void GérerLesTirs()
    {
        tempsRestantPourTirer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && tempsRestantPourTirer <= 0f)
        {
            if (tirPuissant)
            {
                TirerProjectilePuissant(); // Utilise le projectile puissant si le bonus est activé
            }
            else
            {
                TirerProjectileSimple(); // Utilise le projectile simple par défaut
            }
            tempsRestantPourTirer = tempsEntreTirs;
        }
    }

    void TirerProjectileSimple()
    {
        Instantiate(projectileSimple, pointDeTir.position, pointDeTir.rotation);
    }

    void TirerProjectilePuissant()
    {
        Instantiate(projectilePuissant, pointDeTir.position, pointDeTir.rotation);
    }

    void ChangerModeDeTir()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            modeDeTir = 1; // Mode de tir simple
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            modeDeTir = 2; // Mode de tir multiple
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            modeDeTir = 3; // Mode laser
        }
    }

    // Méthode de collision avec les ennemis ou projectiles ennemis
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "ProjectileEnnemi")
        {
            PrendreDesDégâts(1); // Le vaisseau prend des dégâts lorsqu'il touche un ennemi ou un projectile
        }
    }

    // Gestion des dégâts
    public void PrendreDesDégâts(int dégâts)
    {
        pointsDeVie -= dégâts;
        if (pointsDeVie <= 0)
        {
            DetruireVaisseau();
        }
    }

    // Destruction du vaisseau
    void DetruireVaisseau()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Explosion du vaisseau
        FindObjectOfType<GameOverManager>().AfficherGameOver(); // Affiche l'écran de Game Over
        Destroy(gameObject); // Détruit le vaisseau
    }

    // Méthode pour activer un bonus de vitesse
    public void ActiverBonusVitesse(float augmentation, float durée)
    {
        StartCoroutine(AugmenterVitesse(augmentation, durée));
    }

    // Coroutine pour gérer le bonus de vitesse
    private IEnumerator AugmenterVitesse(float augmentation, float durée)
    {
        vitesse += augmentation; // Augmente la vitesse
        yield return new WaitForSeconds(durée); // Attend la fin du bonus
        vitesse -= augmentation; // Rétablit la vitesse normale
    }
}
