using UnityEngine;
using System.Collections;

public class VaisseauSpatial : MonoBehaviour
{
    public float vitesse = 10f; // Vitesse de d�placement du vaisseau
    public GameObject projectileSimple; // Projectile simple
    public GameObject projectilePuissant; // Projectile puissant
    public Transform pointDeTir; // Point de tir du projectile
    public float tempsEntreTirs = 0.5f; // Temps entre les tirs
    private float tempsRestantPourTirer = 0f; // Chrono avant le prochain tir
    public int modeDeTir = 1; // Mode de tir : 1 = simple, 2 = multiple, 3 = laser

    public bool tirPuissant = false; // Bonus de tir puissant activ� ou non
    public int pointsDeVie = 3; // Points de vie du vaisseau
    public GameObject explosionPrefab; // Explosion � instancier en cas de destruction du vaisseau

    void Start()
    {
        // On s'assure que ce script ne s'applique qu'� l'objet avec le tag "Joueur"
        if (gameObject.tag != "Joueur")
        {
            Destroy(this);
        }
    }

    void Update()
    {
        D�placerVaisseau();
        G�rerLesTirs();
        ChangerModeDeTir(); // Permet de changer de mode de tir
    }

    void D�placerVaisseau()
    {
        float mouvementHorizontal = Input.GetAxis("Horizontal");
        float mouvementVertical = Input.GetAxis("Vertical");
        Vector3 deplacement = new Vector3(mouvementHorizontal, mouvementVertical, 0f);
        transform.Translate(deplacement * vitesse * Time.deltaTime);
    }

    void G�rerLesTirs()
    {
        tempsRestantPourTirer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && tempsRestantPourTirer <= 0f)
        {
            if (tirPuissant)
            {
                TirerProjectilePuissant(); // Utilise le projectile puissant si le bonus est activ�
            }
            else
            {
                TirerProjectileSimple(); // Utilise le projectile simple par d�faut
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

    // M�thode de collision avec les ennemis ou projectiles ennemis
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "ProjectileEnnemi")
        {
            PrendreDesD�g�ts(1); // Le vaisseau prend des d�g�ts lorsqu'il touche un ennemi ou un projectile
        }
    }

    // Gestion des d�g�ts
    public void PrendreDesD�g�ts(int d�g�ts)
    {
        pointsDeVie -= d�g�ts;
        if (pointsDeVie <= 0)
        {
            DetruireVaisseau();
        }
    }

    // Destruction du vaisseau
    void DetruireVaisseau()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Explosion du vaisseau
        FindObjectOfType<GameOverManager>().AfficherGameOver(); // Affiche l'�cran de Game Over
        Destroy(gameObject); // D�truit le vaisseau
    }

    // M�thode pour activer un bonus de vitesse
    public void ActiverBonusVitesse(float augmentation, float dur�e)
    {
        StartCoroutine(AugmenterVitesse(augmentation, dur�e));
    }

    // Coroutine pour g�rer le bonus de vitesse
    private IEnumerator AugmenterVitesse(float augmentation, float dur�e)
    {
        vitesse += augmentation; // Augmente la vitesse
        yield return new WaitForSeconds(dur�e); // Attend la fin du bonus
        vitesse -= augmentation; // R�tablit la vitesse normale
    }
}
