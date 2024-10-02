using UnityEngine;

public class ControleTactile : MonoBehaviour
{
    public float vitesse = 10f;
    private Vector3 toucheDépart;
    private bool estTouché = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touche = Input.GetTouch(0);

            if (touche.phase == TouchPhase.Began)
            {
                toucheDépart = touche.position;
                estTouché = true;
            }
            else if (touche.phase == TouchPhase.Moved && estTouché)
            {
                Vector2 direction = touche.position - (Vector2)toucheDépart;
                DéplacerVaisseau(direction);
            }
            else if (touche.phase == TouchPhase.Ended)
            {
                estTouché = false;
            }
        }
    }

    void DéplacerVaisseau(Vector2 direction)
    {
        Vector3 mouvement = new Vector3(direction.x, direction.y, 0f).normalized;
        transform.Translate(mouvement * vitesse * Time.deltaTime);
    }
}
