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
 
   // Start is called before the first frame update
   void Start()
   {     
      moveActionz.Enable();
   }
   // Update is called once per frame
   void Update()
   {


     move = moveActionz.ReadValue<Vector2>();

     Debug.Log(move);
   }


   // FixedUpdate has the same call rate as the physics system
   void FixedUpdate()
   {
      Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
      transform.position = position;
   }

     
   public void ChangeHealth(int amount)
   { 
      currentHealth = Mathf.Clamp(currentHealth = amount, 0, maxHealth);
      Debug.Log(currentHealth + "/" + maxHealth);
   }
   
} 
