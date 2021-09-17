using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Database;

using System.Linq;

public class GameoverManager : MonoBehaviour
{
    public class Record
    {
        public string userID;
        public int score;
        public string date;

        public Record()
        {
            this.userID = SystemInfo.deviceUniqueIdentifier;
            this.score = 0;
            this.date = "";
        }

        public Record(int score, string date)
        {
            userID = SystemInfo.deviceUniqueIdentifier;
            this.score = score;
            this.date = date;
        }

        public Record(string userID, int score, string date)
        {
            this.userID = userID;
            this.score = score;
            this.date = date;
        }

        public Dictionary<string, System.Object> ToDictionary()
        {
            Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
            result["userID"] = this.userID;
            result["score"] = this.score;
            result["date"] = this.date;

            return result;
        }
    }

    public static GameoverManager instance;


    AudioSource button;

    public Text myScoreText;
    public Text dateText;

    public GameObject scoreUIObj;
    int gameScore;
    string gameDate;

    public GameObject rankingboard;
    List<Record> records = new List<Record>();
    public int rankingSize = 3;

    public GameObject refreshButton;


    DatabaseReference reference;
    bool scoreLoadFlag = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<AudioSource>();

        if (ScoreManager.instance != null)
            gameScore = ScoreManager.instance.currentScore;
        gameDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        myScoreText.text = gameScore.ToString();
        dateText.text = gameDate;


        reference = FirebaseDatabase.DefaultInstance.RootReference;
        if (ScoreManager.instance != null)
            RankingUpload();


        RankingLoad();
    }

    private void LateUpdate()
    {
        if (scoreLoadFlag == true)
        {
            refreshButton.SetActive(false);
            UpdateRankingboard();
        }
    }

    public void onClickRetry()
    {
        button.Play();
        SceneManager.LoadScene("IntroScene");
    }

    public void onClickExit()
    {
        button.Play();
        Application.Quit();
    }

    public void onClickRefresh()
    {
        RankingLoad();
    }

    void RankingUpload()
    {
        Record currentRecord = new Record(gameScore, gameDate);
        string json = JsonUtility.ToJson(currentRecord);

        Record pastRecord = new Record();
        // 본인 점수를 불러옴
        reference.Child("high_score").Child(currentRecord.userID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                print("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshots = task.Result;

                // snapshot의 자식 개수
                print(snapshots.ChildrenCount);

                foreach (DataSnapshot snapshot in snapshots.Children)
                {
                    IDictionary record = (IDictionary)snapshot.Value;

                    pastRecord = new Record(int.Parse(record["score"].ToString()), record["date"].ToString());
                }

                scoreLoadFlag = true;
            }
        });


        // 현재점수와 비교해서 더 높으면 업데이트
        // reference.Child("high_score").Child(System.DateTime.Now.ToString()).SetRawJsonValueAsync(json);
        // reference.Child("high_score").Child(SystemInfo.deviceUniqueIdentifier).SetRawJsonValueAsync(json);
        if (gameScore > pastRecord.score)
            WriteNewScore(currentRecord);
    }

    void WriteNewScore(Record record)
    {
        string key = reference.Child("high_score").Child(record.userID).Push().Key;

        Dictionary<string, System.Object> recordValues = record.ToDictionary();

        Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();

        childUpdates["/high_score/" + record.userID] = recordValues;
        reference.UpdateChildrenAsync(childUpdates);
    }

    public void RankingLoad()
    {
        reference.Child("high_score").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                print("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshots = task.Result;

                // snapshot의 자식 개수
                print(snapshots.ChildrenCount);

                foreach (DataSnapshot snapshot in snapshots.Children)
                {
                    IDictionary record = (IDictionary)snapshot.Value;
                    records.Add(new Record(record["userID"].ToString(), int.Parse(record["score"].ToString()), record["date"].ToString()));
                }

                scoreLoadFlag = true;
            }
            else if (task.IsCanceled)
            {
                refreshButton.SetActive(true);
            }
        });
    }

    void UpdateRankingboard()
    {
        scoreLoadFlag = false;

        List<Record> sorted = records.OrderByDescending(record => record.score).ToList();

        for (int i = 0; i < rankingSize && i < sorted.Count; ++i)
        {
            GameObject scoreUI = Instantiate(scoreUIObj);
            scoreUI.transform.SetParent(rankingboard.transform);
            SetScoreUI(scoreUI, sorted[i].score, sorted[i].date, i + 1);
        }
    }

    void SetScoreUI(GameObject scoreUI, int score, string date, int rank)
    {
        scoreUI.transform.Find("Rank").GetComponent<Text>().text = rank.ToString();
        scoreUI.transform.Find("Score").GetComponent<Text>().text = score.ToString();
        scoreUI.transform.Find("Date").GetComponent<Text>().text = date;
    }
}
