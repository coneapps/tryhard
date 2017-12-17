using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GPGS : MonoBehaviour {

    public void Start()
    {
        PlayGamesPlatform.Activate();
    }

    public void sign()
    {
        if (isSigned())
        {
            PlayGamesPlatform.Instance.SignOut();
        }
        else
        {
            Social.localUser.Authenticate((bool success) => { Debug.Log(success); });
        }
    }

    public void showAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void showLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }

    public void load(string leaderboardID, string scoreType)
    {
        PlayGamesPlatform.Instance.LoadScores(leaderboardID, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime, (LeaderboardScoreData data) =>
        {
            if (data.Valid)
            {
                int score = int.Parse(data.PlayerScore.formattedValue);
                PlayerPrefs.SetInt(scoreType, score);
            }
        });
    }

    public void unlockAchivement(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) => { });
    }

    public void postScore(int score, string id)
    {
        Social.ReportScore(score, id, (bool success) => { });
    }

    public bool isSigned()
    {
        return Social.localUser.authenticated;
    }
}
