using UnityEngine;

public class MusiqueDeFond : MonoBehaviour
{
    public AudioSource musique; // La musique de fond (fichier audio attach� � l'AudioSource)

    void Start()
    {
        musique.Play(); // D�marre la musique � l'initialisation du jeu
    }
}
