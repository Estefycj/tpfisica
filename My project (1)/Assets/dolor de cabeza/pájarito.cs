using UnityEngine;
using UnityEngine.InputSystem;
public class pajarito : MonoBehaviour
{
      [SerializeField] private float force;
      [SerializeField] private float maxDistance;

      private Camera mainCamara; 
      private Rigidbody2D rb;
      private Vector2 startPosition, clampedPosition;

    void Start()
    {
        mainCamara = Camera.main;
        rb = GetComponent<Rigidbody2D>(); 
        rb.isKinematic = true; 
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
       SetPosition();
    }

    private void SetPosition()
    {
        Vector2 dragPosition = mainCamara.ScreenToWorldPoint(Input.mousePosition);
        clampedPosition = dragPosition;

        float dragDistance = Vector2.Distance(startPosition, dragPosition);

        if(dragDistance > maxDistance) 
        {
                clampedPosition = startPosition + (dragPosition - startPosition).normalized * maxDistance;
        }

        if(dragPosition.x > startPosition.x)
        {
                clampedPosition.x = startPosition.x;
        }

        transform.position = clampedPosition;
    }

// bueno.. ya este punto mi pobre cerebro no aguantaba tan info junta 

    private void OnMouseUp()
    {
        Throw();

    }

    private void Throw()
    {
        rb.isKinematic = false;
        Vector2 thronVector = startPosition - clampedPosition;
        rb.AddForce(thronVector * force);

        float resetTime = 3f;
        Invoke("Reset", resetTime);
    }

    private void Reset()
    {
        transform.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        mainCamara.GetComponent<camarita>() .ResetPosition();

    }
}
