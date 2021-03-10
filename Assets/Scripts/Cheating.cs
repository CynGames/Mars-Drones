using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Cheating : MonoBehaviour
{
    Manager manager;
    bool hasCheated;

    private void Start()
    {
        manager = manager ? manager : FindObjectOfType<Manager>();
    }

    void Update()
    {
        if ((Input.touchCount > 7 || Input.GetKeyDown(KeyCode.O)) && hasCheated == false)
        {
            hasCheated = true;

            var sceneName = SceneManager.GetActiveScene().name;
            AnalyticsEvent.LevelSkip($"CheatSkipped: {sceneName}");
            
            manager.MinigameOver();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChampionsClubMember();
        }
    }

    [ContextMenu("Champions Club Member")]
    public void ChampionsClubMember()
    {
        manager.MinigameOver();
    }
}
