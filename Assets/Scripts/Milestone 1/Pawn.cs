//Pawn: For the mode/player itself

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    private GameManager gm;
    //Animator
    public Animator anim;
    private GameObject character;
    public Weapon equippedWeapon;
    //Current Speed for the character.
    public float currentSpeed = 1f;
    public float currentHealth;
    public float maxHealth;

    public WeightedItems itemDrop;
    public float radius;
    private List<Collider> objectsInTrigger = new List<Collider>();
    public float tickRate = 0.333333f;
    public float countDown = 10;
    private Health health;

    //Attachments and Joints
    public Transform attachmentPoint;
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    public NavMeshAgent agent;

    public EnemySpawner enemySpawnCount;
    // events
    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;
    public UnityEvent onDeath;
    [Range(0.0f, 1.0f)] public float IKweight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        enemySpawnCount = GetComponent<EnemySpawner>();
        character = this.gameObject;
        itemDrop = GetComponent<WeightedItems>();
    }
    private void Awake()
    {
        gm = GameManager.instance;
    }
    // Update is called once per frame
    void Update()
    {

    }
    //Add Health
    public void AddHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;
    }
    //Add Poison or Lose Health
    public void AddPoison(float poisonEffect)
    {
        //countDown -= Time.deltaTime;
        //if (countDown < 0)
        //{
        //    currentHealth -= poisonEffect = Time.deltaTime;
        //    countDown = tickRate;
        //}
        currentHealth -= poisonEffect;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth == 0)
        {
            itemDrop.RNG();
            onDeath.Invoke();
            Destroy(character, 2.0f);
        }
    }

    //One touch death
    public void AddDeath(float death)
    {
        //countDown -= Time.deltaTime;
        //if (countDown < 0)
        //{
        //    currentHealth -= poisonEffect = Time.deltaTime;
        //    countDown = tickRate;
        //}
        currentHealth -= death;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth == 0)
        {
            
            onDeath.Invoke();
            itemDrop.RNG();
            //Destroy(character, 2.0f);
        }
    }
    //Damage Function
    public void Damage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth == 0)
        {
            
            onDeath.Invoke();
            //GameManager.instance.EnemyItem();
            Destroy(character, 2.0f);
            //enemySpawnCount.EnemyDeath();
        }

    }
    //Movement on Vector2 since it focuses on top-down view.
    public void Move(Vector3 direction)
    {
        anim.SetFloat("Horizontal", direction.x * currentSpeed);
        anim.SetFloat("Vertical", direction.z * currentSpeed);
    }
    //Equip Weapon
    public void EquipWeapon(Weapon newWeapon)
    {
        if (equippedWeapon != null)
        {
            UnequipWeapon();
        }
        // try out different instantiates

        GameObject weaponObject = Instantiate(newWeapon.gameObject, attachmentPoint.position, attachmentPoint.rotation) as GameObject;
        weaponObject.transform.parent = attachmentPoint;
        
        equippedWeapon = weaponObject.GetComponent<Weapon>();
        GameManager.instance.weaponIMG.GetComponent<Image>().sprite = equippedWeapon.weaponIMG;
        // change the layer
        equippedWeapon.gameObject.layer = gameObject.layer;
        OnTriggerPull.AddListener(equippedWeapon.OnPullTrigger);
        OnTriggerRelease.AddListener(equippedWeapon.OnReleaseTrigger);
    }

    //Unequip Weapon
    public void UnequipWeapon()
    {
        OnTriggerPull.RemoveListener(equippedWeapon.OnPullTrigger);
        OnTriggerRelease.RemoveListener(equippedWeapon.OnReleaseTrigger);
        GameManager.instance.weaponIMG.GetComponent<Image>().sprite = null;
        Destroy(equippedWeapon.gameObject);
        equippedWeapon = null;
    }
    //private void OnAnimatorMove()
    //{
    //    if (agent != null);
    //    else if (agent == null) anim.ApplyBuiltinRootMotion();
    //}

    //Animator IK for the arms
    public void OnAnimatorIK()
    {
        //Right Hand
        if (equippedWeapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
            return;
        }
        if (equippedWeapon.rightHand != null)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.rightHand.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKweight);
            anim.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.rightHand.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKweight);

        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }
        //Left Hand
        if (equippedWeapon.leftHand != null)
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.leftHand.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKweight);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.leftHand.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKweight);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}

