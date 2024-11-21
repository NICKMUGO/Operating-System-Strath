using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rigidBody;
   [SerializeField] private SpriteRenderer spriteRenderer;
   [SerializeField] private float jumpForce = 6; 
   [SerializeField] private float doubleJumpForce = 6f;
   [SerializeField] private Vector2 wallJumpForce = new Vector2(4f, 8f);
   private float playerHalfHeight;
   private float playerHalfWidth;
   private bool canDoubleJump;
    private void Start()
    {
         playerHalfWidth = spriteRenderer.bounds.extents.x;
         playerHalfHeight = spriteRenderer.bounds.extents.y;
    }
   

   void Update()
   {
        if (Input.GetButtonDown("Jump"))
        {
            CheckJumpType();
        }
        
   }
   private void CheckJumpType()
   {
    bool isGrounded = GetIsGrounded();

        if  (isGrounded){
            Jump(jumpForce);
        }
        else if                                                                                                                                    (canDoubleJump)
        {
            int direction = GetWallJumpDirection();
            if (direction == 0 && canDoubleJump){
                DoubleJump();
            }
            else if (direction != 0){
                WallJump(direction);
            }

            
        }
   }

   private int GetWallJumpDirection(){
    if (Physics2D.Raycast(transform.position, Vector2.right, playerHalfWidth + 0.1f, LayerMask.GetMask("Ground"))){
        return -1;
    }
    else if (Physics2D.Raycast(transform.position, Vector2.left, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"))){
        return 1;
    }

    return 0;
   }
   private bool GetIsGrounded(){
        bool hit = Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.5f, LayerMask.GetMask("Ground"));
        if(hit){
            canDoubleJump = true;
        }
        return hit;
   }

    private void DoubleJump(){
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        Jump(doubleJumpForce);
        canDoubleJump = false;

    }
    private void WallJump(int direction){
        Vector2 force = wallJumpForce;
        force.x *= direction;
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        rigidBody.AddForce(force, ForceMode2D.Impulse);

        
    }
   private void Jump(float force){
        rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);

   }
}
