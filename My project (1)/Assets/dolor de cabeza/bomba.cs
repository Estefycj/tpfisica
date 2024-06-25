using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour

{
    // espero que me aprube con la minima si no, no le regalo arepas
    
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
         
           {
           Explosion();

           }   

      public void Explosion()
     { 
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if(rb2D !=null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzafinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzafinal);
            }

       }
     
       
     }
 
    private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, radio);
    }
  


}


