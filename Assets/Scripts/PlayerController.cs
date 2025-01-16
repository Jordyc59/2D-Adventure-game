using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
  public InputAction moveActionz;
  Rigidbody2D rigidbody2d;
  Vector2 move;
  public float speed = 3.0f;
  // Variables related to the health system
  public int maxHealth = 5;
  int currentHealth = 1;
  public int health { get { return currentHealth;}}
   // Variables related to temporary Invincibility
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    // Variable related to animation
    Animator animator;
    Vector2 moveDirection = new Vector2(1,0);

    // Variables related to projectile
    public GameObject projectilePrefab;

   // Start is called before the first frame update
   void Start()
   {     
      moveActionz.Enable();
      rigidbody2d = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();

      currentHealth = maxHealth;
   }
   // Update is called once per frame
   void Update()
   {
     move = moveActionz.ReadValue<Vector2>();
     Debug.Log(move);
     
     if(!Mathf.Approximately(move.x,0.0f) || !Mathf.Approximately(move.y,0.0f))
     {
      moveDirection.Set(move.x, move.y);
      moveDirection.Normalize();
     }
      if (isInvincible)
      {
         damageCooldown -= Time.deltaTime;
      
         if (damageCooldown < 0)
         {
            isInvincible = false;
            
         }

          
      }

       if(Input.GetKeyDown(KeyCode.C))
         {
            Launch();
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
void Launch()
  {
     GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
     Projectile projectile = projectileObject.GetComponent<Projectile>();
     projectile.Launch(moveDirection, 300);


     animator.SetTrigger("Launch");
  }
} 