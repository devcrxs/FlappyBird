using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

   [SerializeField] private float expEarn = 25f;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         BarraExp barraExp = other.GetComponent<BarraExp>();

         if (barraExp != null)
         {
            barraExp.SetExp(expEarn); 
         }
         
         Destroy(gameObject);
         
      }
      

   }
   
}
