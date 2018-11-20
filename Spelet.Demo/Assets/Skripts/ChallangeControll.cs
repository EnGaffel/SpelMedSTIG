using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeControll : MonoBehaviour {

    private bool spelareScroll = false;
    public float scrollSpeed = 5.0f;  // hastighet på utmaningarna
    public GameObject[] challenges;
    public float frequency = 1f;
    float counter = 0f;
    public Transform challengesSpawnPoint;
    public Transform player;
    public GameObject spelare;
    public GameObject startplatta, CountDown;

    //private SpelareKontroller Kontroll;


    // Use this for initialization
    void Start() {
        GenerateRandom();
        CountDown.SetActive(true);
        //Kontroll = GameObject.Find( "Player").GetComponent<SpelareKontroller>();
        //Kontroll.SlowDown = false;
    }

    void OnEnable()
    {
        StartCoroutine(waitForScroll());
    }

    // Update is called once per frame
    void Update() {

          scrollChallange(startplatta);

        if (spelareScroll)
        {
            CountDown.SetActive(false);

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                scrollChallange(spelare);
            }
            else
            {
                //  scrollChallange(spelare);  // spelare rör sig med "frikton" till utmaningarna om man inte klickar några knappar
            }
            if (counter <= 0.0f)
            {
                GenerateRandom();
            }
            else
            {
                counter -= Time.deltaTime * frequency;
              
            }
            GameObject currentChild;

            for (int i = 0; i < transform.childCount; i++)
            {
                currentChild = transform.GetChild(i).gameObject;
                scrollChallange(currentChild);
                if (currentChild.transform.position.x <= -80.0f)  // här tar man bort utmaningen vid -15
                {
                    Destroy(currentChild);
                }
            }
        }

        //if (Kontroll.SlowDown == true)
        //{
        //    scrollSpeed = scrollSpeed / 2;  //hastigheten på utmaningarna ökar
        //    frequency = frequency / 2;   //frekvensen som utmaningarna genereras på öker med samma procentsats
        //    Kontroll.SlowDown = false;
        //}

    }

    public void scrollChallange(GameObject currentChallange)
    {
        currentChallange.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);

        scrollSpeed = scrollSpeed;  //hastigheten på utmaningarna ökar
        frequency = frequency;   //frekvensen som utmaningarna genereras på öker med samma procentsats
    }
    
    void GenerateRandom()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;

        counter = 5.0f;

        // mellanrum mellan spawns
    }

    IEnumerator waitForScroll()
    {
        yield return new WaitForSeconds(3);
        spelareScroll = true;
    }
}
 