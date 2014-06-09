using UnityEngine;
using System.Collections;


/// <summary>
/// Store pick up items and player state
/// </summary>
public class PlayerProperties : MonoBehaviour
{

    public enum PlayerState { MarioDead, MarioSmall, MarioLarge, Mariofire };
    public PlayerState currentState = PlayerState.MarioSmall;

    public int lives = 3;
    public int keys = 0;
    public int coins = 0;
    public GameObject proyectileFire;

    public Transform projectileScoketRight;
    public Transform projectileScoketLeft;

    public Material materialMarioStandard;
    public Material materialMarioFire;

    public bool changeMario = false;
    public bool hasFire = false;


    private int coinLife = 20;
    private bool canShoot = false;
    private PlayerControl playerContols;
    private CharacterController charController;

    void Start()
    {
        playerContols = GetComponent<PlayerControl>();
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (changeMario)
        {
            SetPlayerstate();
        }

        if (canShoot)
        {
            Shoot();
        }
        else
        {
            return;
        }

    }

    private void Shoot()
    {
        GameObject clone;
        if (Input.GetButtonDown("Fire1") && proyectileFire)
        {
            Debug.Log("Shoot pressed");
            if (playerContols.moveDirection == 0 /*left side*/)
            {
                clone = (GameObject)Instantiate(proyectileFire, projectileScoketLeft.transform.position, transform.rotation);
                clone.rigidbody.AddForce(-90, 0, 0);
            }
            else
            {
                clone = (GameObject)Instantiate(proyectileFire, projectileScoketRight.transform.position, transform.rotation);
                clone.rigidbody.AddForce(90, 0, 0);
            }
        }
    }

    public void AddKeys(int numKeys)
    {
        this.keys += numKeys;
    }
    public void AddCoin(int numCoins)
    {
        this.coins += numCoins;
    }

    public void SetPlayerstate()
    {

        switch (currentState)
        {
            case PlayerState.MarioSmall:
                SetSmallSking(materialMarioStandard);
                canShoot = false;
                break;
            case PlayerState.MarioLarge:
                SetLargeSkings(materialMarioStandard);
                canShoot = false;
                break;
            case PlayerState.Mariofire:
                SetLargeSkings(materialMarioFire);
                canShoot = true;
                break;
            case PlayerState.MarioDead:
                Destroy(gameObject);
                break;
        }
        changeMario = false;
    }

    private void SetLargeSkings(Material material)
    {
        playerContols.gravity = 0F;
        transform.Translate(0, 0.2F, 0);
        transform.localScale = new Vector3(1F, 1F, 1F); ;
        charController.height = 0.5F;
        transform.renderer.material = material;
        playerContols.gravity = 20F;
    }

    private void SetSmallSking(Material material)
    {
        playerContols.gravity = 0F;
        transform.Translate(0, 0.2F, 0);
        transform.localScale = new Vector3(1F, 0.75F, 1F);
        charController.height = 0.45F;
        transform.renderer.material = material;
        playerContols.gravity = 20F;
    }
}
