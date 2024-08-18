using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : MonoBehaviour
{
    private int life;
    [SerializeField] private List<Sprite> healthSprites;
    
    private static Life _instance;

    public static Life Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Life>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject("Life");
                    _instance = singleton.AddComponent<Life>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return _instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {  
        life = 6;
        this.SetHealthSprite();
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthSprite() {
        gameObject.GetComponent<SpriteRenderer>().sprite = healthSprites[life];
    }

    public void DecreaseLife() {
        life--;
        if (life < 0) {
            Debug.Log("GameOver");
            //SceneManager.LoadScene("GameOver");
        } else {
            this.SetHealthSprite();
        }
    }
}
