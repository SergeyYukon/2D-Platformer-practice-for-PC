using UnityEngine;

[RequireComponent(typeof(IDamageAble), typeof(IParameters))]
public class Health : GameManager
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private IParameters iParameters;
    private IDamageAble iDamageAble;

    private void Awake()
    {
        iDamageAble = gameObject.GetComponent<IDamageAble>();
        iParameters = gameObject.GetComponent<IParameters>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        iParameters.HealthBar(currentHealth, maxHealth);
        iDamageAble.GetDamage();
        if (currentHealth <= 0)
        {
            iDamageAble.Death();
        }
    }

    public void GetHeal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        iParameters.HealthBar(currentHealth, maxHealth);
    }
}
