using UnityEngine;

public class camarita : MonoBehaviour
{
    [SerializeField] private Transform pajaritoTransform;
    [SerializeField] private float xStopPosition;
    
    private Vector3 startPosition;

    void Start()
    {
       startPosition = transform.position;
    }
private void LateUpdate()
{
    if(pajaritoTransform.position.x > transform.position.x && transform.position.x < xStopPosition)
    {
        transform.position = new Vector3(pajaritoTransform.position.x, transform.position.y,transform.position.z);
    }
}
   public void ResetPosition()
{
    transform.position = startPosition;
}

}

