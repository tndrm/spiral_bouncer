using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelBuilder _builder;
    [SerializeField] List<LevelModel> levelModels = new List<LevelModel>();
    [SerializeField] PanelManager panelManager;


    [SerializeField] private ProgressBar progressBar;
    private Ball ball;
    private int currentLevel = 0;
    void Start()
    {
        _builder.Build(levelModels[currentLevel].platformCount, levelModels[currentLevel].platforms);
        ball = FindAnyObjectByType<Ball>();
		ball.OnLevelProgressChangedEvent += IncreaseLevelProgress;
		ball.OnLevelPassedEvent += ShowWinPanel;

		progressBar.SetCurrentLevel(currentLevel);
		IncreaseLevelProgress(0);
    }

    private void IncreaseLevelProgress(int progress)
    {
        progressBar.UpdateCurrentValue((float)progress / levelModels[currentLevel].platformCount);
	}

    private void ShowWinPanel()
    {
        panelManager.ShowWinPanel();
	}


}
