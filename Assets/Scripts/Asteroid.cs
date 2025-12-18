using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30f;
    private SpriteRenderer _spriteRedenrer;
    private Rigidbody2D _rb;
    private CircleCollider2D _collider;
    public LogicScript logic;
    

    private void Awake()
    {
        _spriteRedenrer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _spriteRedenrer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rb.mass = this.size * 2.0f;
         if (logic == null)
        {
            GameObject logicObj = GameObject.FindGameObjectWithTag("Logic");
            if (logicObj != null)
                logic = logicObj.GetComponent<LogicScript>();
        }
    }

    public void InitializeAsteroid()
    {
        
        _spriteRedenrer.sprite = sprites[Random.Range(0, sprites.Length)];

        
        transform.localScale = Vector3.one * size;
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        
        _rb.mass = size * 2f;

        
        if (_collider != null)
            _collider.radius = 0.5f * size; 
    }

    public void SetTraJectory(Vector2 direction)
    {
        _rb.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "teleportable")
        {
            Debug.Log("point");
            if (logic != null)
            {
                 logic.addScore(10);
            }
               
            if ((this.size * 0.5f) >= this.minSize)
            {
                Createsplit();
                Createsplit();
            }

            Destroy (this.gameObject);
        }
    }

    private void Createsplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size =this.size * 0.5f;

        half.transform.localScale = Vector3.one * half.size;
        half.InitializeAsteroid();

        half.SetTraJectory(Random.insideUnitCircle.normalized * this.speed);
    }
}

