using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageInterval = 1f;
    AudioSource damageSound; 
    private float lastDamageTime;
    void Start() {
        damageSound = GetComponent<AudioSource>();
    }
void OnTriggerStay2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (Time.time - lastDamageTime >= damageInterval)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && GameController.IsRodando)
            {
                player.TakeDamage();
                damageSound.Play();
                lastDamageTime = Time.time;
            }
        }
    }
}

}
