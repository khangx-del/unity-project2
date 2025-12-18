
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   [Header("Ship parameters")]
   [SerializeField] private float thrust = 10f;
   [SerializeField] private float maxSpeed = 10f;
   [SerializeField] private float rotationSpeed = 180f;
   [SerializeField] private float drag = 1.5f;
   public Shoot shootPrefabs;
   public LogicScript logic;
   private Rigidbody2D rb;
   private bool isAccelerating = false;

    [System.Obsolete]
    private void Start()
   {
      rb = GetComponent<Rigidbody2D>();  
      rb.drag = 1.5f;   
   }
   
   private void Update()
   {
      isAccelerating = Input.GetKey(KeyCode.UpArrow);
      float rotateInput = 
        
      Input.GetKey(KeyCode.LeftArrow) ? 1 :
      Input.GetKey(KeyCode.RightArrow) ? -1 : 0;

      transform.Rotate(0f, 0f, rotateInput * rotationSpeed * Time.deltaTime);

      if (Input.GetKeyDown(KeyCode.Space))
      {
      Shoot();
      }
   }
   private void FixedUpdate()
   {
      if(isAccelerating && rb.linearVelocity.magnitude < maxSpeed * 10f)
      {
         rb.AddForce(transform.up * thrust);        
      } 
   }
   private void Shoot()
   {
      Shoot shoot = Instantiate(this.shootPrefabs, this.transform.position, this.transform.rotation);
      shoot.Project(this.transform.up);
   }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
      {
         rb.velocity = Vector3.zero;
         rb.angularVelocity = 0.0f;   
         this.gameObject.SetActive(false);    
         logic.GameOver();      
      }
    }
    
}
