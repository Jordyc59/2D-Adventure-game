using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
  public InputAction moveActionz;
  Vector2 move;
  // Variables related to the health system
  public int maxHealth = 5;
  int currentHealth = 1;
  public int health { get { return currentHealth;}}
   // Variables related to temporary Invincibility
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
   // Start is called before the first frame update
   void Start()
   {     
      moveActionz.Enable();
      currentHealth = maxHealth;
   }
   // Update is called once per frame
   void Update()
   {
     move = moveActionz.ReadValue<Vector2>();
     Debug.Log(move);
      if (isInvincible)
      {
         damageCooldown -= Time.deltaTime;
      
         if (damageCooldown < 0)
         {
            isInvincible = false;
            
         }
      }
   }
     
   // FixedUpdate has the same call rate as the physics system
   void FixedUpdate()
   {
      Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
      transform.position = position;
   }  
   public void ChangeHealth(int amount)
   { 
      if (amount < 0)
      {
         if (isInvincible)
         { 
            return;
         }   
         isInvincible = true;
         damageCooldown = timeInvincible;
      }
      currentHealth = Mathf.Clamp(currentHealth = amount, 0, maxHealth);
      Debug.Log(currentHealth + "/" + maxHealth);
   }

} 