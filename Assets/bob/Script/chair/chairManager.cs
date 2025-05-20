using UnityEngine;

public class chairManager : MonoBehaviour
{
    [SerializeField] private float masatu;
    private Rigidbody2D rd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.linearDamping = 5.0f;
        rd.angularDamping = 5.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
