using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	private GameManager _gameManager;

	public void LoadLevel(string scenename)
	{
		LoadScene(scenename);
	}

	public void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Load Scene: " + scene.name);

		if (scene.name.StartsWith("GrassLevel"))
		{
			SpawnPlayerAtSpawnPoint();
		}
		else if (scene.name.StartsWith("HouseLevel"))
		{
			SpawnPlayerAtSpawnPoint();
		}
	}

	void LoadScene(string sceneToLoad)
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		Time.timeScale = 1.0f;

		if (sceneToLoad != null)
		{
			if (sceneToLoad.StartsWith("GrassLevel"))
			{
				_gameManager.gameState = GameManager.GameState.GamePlay;
			}
			else if (sceneToLoad.StartsWith("MainMenu"))
			{
				_gameManager.gameState = GameManager.GameState.MainMenu;
			}
			else if (sceneToLoad.StartsWith("HouseLevel"))
			{
				_gameManager.gameState = GameManager.GameState.GamePlay;
			}
			else if (sceneToLoad.StartsWith("End"))
			{
				_gameManager.gameState = GameManager.GameState.LoseMenu;
			}

			SceneManager.LoadScene(sceneToLoad);
		}
	}

	private void SpawnPlayerAtSpawnPoint()
	{
		if (_gameManager != null && _gameManager.player != null)
		{
			GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
			if (spawnPoint != null)
			{
				_gameManager.player.transform.position = spawnPoint.transform.position;
			}
			else
			{
				Debug.LogError("no spawn");
			}
		}
		else
		{
			Debug.LogError("something else is broken");
		}
	}

	public void LoadEndScene()
	{
		SceneManager.LoadScene("End");
	}

	public void LoadHouseLevel()
	{
		SceneManager.LoadScene("HouseLevel");
	}
}
