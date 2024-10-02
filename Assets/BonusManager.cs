using UnityEngine;

public class BonusManger : MonoBehaviour
{
    public float augmentationVitesse = 2f; // Augmentation de la vitesse
    public GameObject bouclierPrefab; // Bonus de bouclier
    public GameObject tirPuissantPrefab; // Bonus pour tir plus puissant
    public float duréeBonus = 10f;

    void Update()
    {
        // Bonus descend vers le joueur
        transform.Translate(Vector3.down * 2f * Time.deltaTime);

        // Détruire le bonus s'il sort de l'écran
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Lorsque le joueur récupère le bonus
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Joueur")
        {
            collision.gameObject.GetComponent<VaisseauSpatial>().ActiverBonusVitesse(augmentationVitesse, duréeBonus);
            Destroy(gameObject); // Détruire le bonus après activation
        }
    }
   
    // Active un bouclier temporaire sur le joueur
    public void ActiverBouclier(VaisseauSpatial vaisseau)
    {
        GameObject bouclier = Instantiate(bouclierPrefab, vaisseau.transform.position, Quaternion.identity);
        bouclier.transform.SetParent(vaisseau.transform); // Le bouclier suit le vaisseau
        Destroy(bouclier, duréeBonus); // Le bouclier disparaît après la durée spécifiée
    }

    // Améliore temporairement les tirs du joueur
    public void ActiverTirPuissant(VaisseauSpatial vaisseau)
    {
        vaisseau.tirPuissant = true; // Active le mode de tir puissant
        Invoke("DésactiverTirPuissant", duréeBonus); // Désactive après un certain temps
    }

    void DésactiverTirPuissant()
    {
        FindObjectOfType<VaisseauSpatial>().tirPuissant = false; // Désactive le tir puissant
    }
}

