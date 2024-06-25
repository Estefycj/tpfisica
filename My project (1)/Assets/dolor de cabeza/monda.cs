using UnityEngine;

public class monster : MonoBehaviour
{
    // bueno.. hora de llorar 
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (ShouldDie(collision))
        {
           Destroy(gameObject);
        }
    }
     private bool ShouldDie(Collision2D collision) 
     {
        bool isPajarito = collision.gameObject.GetComponent<pajarito>();

        if (isPajarito)
         {
             return true;
         }

    // y seguimos llorando.. 
       float crushThreshold = -0.5f;
       bool isCrushed = collision.contacts[0].normal.y < crushThreshold;

       if (isCrushed)
       {
        return true;
       }
        return false; 
    }
}

