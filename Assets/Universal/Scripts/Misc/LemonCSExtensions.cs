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
            return File.Exists(file);
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
            return currentScene.buildIndex == 0;
        }

        public static bool IsGamePaused()
        {
            return Time.timeScale == 0;
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
