using UnityEngine;

public class VaisseauMultijoueur : MonoBehaviour
{
    public float vitesse = 10f; // Vitesse de déplacement du vaisseau
    public GameObject projectile; // Le projectile que le vaisseau tire
    public Transform pointDeTir; // Point de tir du projectile
    public float tempsEntreTirs = 0.5f; // Temps entre les tirs
    private float tempsRestantPourTirer = 0f; // Chrono avant le prochain tir
    public KeyCode toucheTir = KeyCode.Space; // Touche pour tirer (paramétrable pour chaque joueur)
    public string axeHorizontal = "Horizontal"; // Axe de déplacement horizontal
    public string axeVertical = "Vertical"; // Axe de déplacement vertical

    void Update()
    {
        DéplacerVaisseau();
        GérerLesTirs();
    }

    void DéplacerVaisseau()
    {
        float mouvementHorizontal = Input.GetAxis(axeHorizontal);
        float mouvementVertical = Input.GetAxis(axeVertical);
        Vector3 deplacement = new Vector3(mouvementHorizontal, mouvementVertical, 0f);
        transform.Translate(deplacement * vitesse * Time.deltaTime);
    }

    void GérerLesTirs()
    {
        tempsRestantPourTirer -= Time.deltaTime;

        if (Input.GetKey(toucheTir) && tempsRestantPourTirer <= 0f)
        {
            TirerProjectile();
            tempsRestantPourTirer = tempsEntreTirs;
        }
    }

    void TirerProjectile()
    {
        Instantiate(projectile, pointDeTir.position, pointDeTir.rotation); // Instancie un projectile
    }
}
