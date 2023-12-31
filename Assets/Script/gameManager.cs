using Unity.Mathematics;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawPoints;
    [SerializeField] private GameObject skeleton, blob, cimetireSkeleton;
    [SerializeField] private experienceBar experienceBar;
    [SerializeField] private CurrencyBar _currencyBar;
    [SerializeField] private GameObject levelUpCanvas;
    private float timeUntilSpawn = 5f, spawnTimer;
    private int _currentLevel = 1;

    public float expMax = 100, currentExp, expAddition = 50, expLevel, totalCurrency;
    public AudioSource lvlUpSound;


    private void Start()
    {
        LoadCoin();
        _currencyBar.SetCurrency(totalCurrency);
        spawnTimer = timeUntilSpawn;
        experienceBar.SetMaxExperience(expMax);
        experienceBar.SetExperience(0);
    }


    public void GainExperience(float expGain)
    {
        currentExp += expGain;
        experienceBar.SetExperience(currentExp);
        if (currentExp >= expMax)
        {
            LevelUp();
        }
    }
    public void GainCurrency(float currencyGain)
    {
        totalCurrency += currencyGain;
        _currencyBar.SetCurrency(totalCurrency);
        SaveCoin();
    }


    private void FixedUpdate()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {

        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                Instantiate(skeleton, spawPoints[0].transform.position, quaternion.identity);
                Instantiate(skeleton, spawPoints[1].transform.position, quaternion.identity);
                Instantiate(blob, spawPoints[2].transform.position, quaternion.identity);
                Instantiate(cimetireSkeleton, spawPoints[3].transform.position, quaternion.identity);

                spawnTimer = timeUntilSpawn;
            }
        }
    }

    public void LevelUp()
    {
        _currentLevel += 1;
        lvlUpSound.Play();
        currentExp = 0;
        experienceBar.SetExperience(0);
        expLevel = expMax + expAddition;
        expMax = expLevel;
        experienceBar.SetMaxExperience(expMax);
        levelUpCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void SaveCoin()
    {
        SaveSystem.SaveCoin(this);
    }

    public void LoadCoin()
    {
        SavingData data = SaveSystem.LoadData();

        totalCurrency = data?.goldCoin ?? 0;
    }
}
