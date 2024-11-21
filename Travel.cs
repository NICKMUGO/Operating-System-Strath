public class ShootingScript : MonoBehaviour

    public GameObject projectilePrefab;
    public Transform muzzlePoint;
    public float projectileSpeed;

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(muzzlePoint.forward * projectileSpeed, ForceMode.Impulse);

         // Play muzzle flash
        muzzleFlash.Play();

        // Play shot sound
        shotSound.PlayOneShot(shotSound.clip);

        // Add recoil animation here (optional)
        // ...
    }

}
