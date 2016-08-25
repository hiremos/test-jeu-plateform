using UnityEngine;

/// <summary>
/// Gestion des points de vie et des dégâts
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// Points de vies
    /// </summary>
    private float actualPv;
    public float totalPv;

    /// <summary>
    /// Ennemi ou joueur ?
    /// </summary>
    public bool isEnemy = true;
    

    void Start()
    {
        actualPv = totalPv;
    }

    public void takeDamage(Collider2D collider)
    {
        // Est-ce un tir ?
        ShotsParameters shot = collider.gameObject.GetComponent<ShotsParameters>();
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy)
            {
                actualPv -= shot.damage;

                if (actualPv <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }    
}