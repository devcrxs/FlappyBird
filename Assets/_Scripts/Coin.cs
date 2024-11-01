using UnityEngine;
public class Coin : MonoBehaviour
{
   [SerializeField] private float expEarn = 25f;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.gameObject.CompareTag("Player")) return;
      GameManager.instance.AddExperience(expEarn);
      UIManager.instance.UpdateExperience();
      Destroy(gameObject);
   }
   
}
