using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LemonStudios.CsExtensions
{
    public static class LemonUtils
    {
        public static bool DoesFileExist(string file)
        {
            if (File.Exists(file))
            {
                return true;
            }
            else return false;
        }

        public static int GetFirstNonNullEntryOfList<T>(List<T> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] != null)
                {
                    return i;
                }
            }
            return -1;  // Return -1 as an error for now
        }
    }

    public static class LemonGameUtils
    {
        public static bool IsOnMainMenu()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex == 0)
            {
                return true;
            }
            else return false;
        }

        public static bool IsGamePaused()
        {
            if (Time.timeScale == 0) return true;
            else return false;
        }

        public static IEnumerator LoadAsyncScene(int sceneBuildIndex)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
