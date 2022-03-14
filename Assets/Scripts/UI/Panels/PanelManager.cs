using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

	[SerializeField] private GameObject parent;
	[SerializeField] private GameObject popupBackground;
	public List<PanelModel> panelList;
	private Ball ball;


	private void Start()
	{
		ball = FindObjectOfType<Ball>();
		ball.OnLevelPassedEvent += ShowWinPanel;
	}

	private void ShowWinPanel()
	{
		ShowPanel("PopUpWin");
	}
	public void ShowPanel(string panelId)
	{
		PanelModel panel = panelList.FirstOrDefault(panel => panel.panelName == panelId);

		if (panel != null)
		{
			popupBackground.SetActive(true);
			var currentPanel = Instantiate(panel.panelPrefab, parent.transform.position, Quaternion.identity, parent.transform);
		}
		else
		{
			Debug.LogError($"You try to use panel '{panelId}', but this is not finds in panels");
		}
	}
}
