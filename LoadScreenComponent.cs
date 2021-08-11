using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ILYTATTools
{
    public static class LoadScreen
    {
        private static GameObject GetLoaderCanvas;
        private static Image GetProgressBar;

        public static void SetLoaderCanvas(GameObject Canvas)
        {
            GetLoaderCanvas = Canvas;
        }

        public static void SetProgressBar(Image progressFill)
        {
            GetProgressBar = progressFill;
        }

        public static void EnableLoadScreen()
        {
            GetLoaderCanvas.SetActive(true);
        }

        public static void DisableLoadScreen()
        {
            GetLoaderCanvas.SetActive(false);
        }

        public static void ResetFill()
        {
            GetProgressBar.fillAmount = 0;
        }

        public static void UpdateFill(float target, float maxDelta)
        {
            GetProgressBar.fillAmount = Mathf.MoveTowards(GetProgressBar.fillAmount, target, maxDelta);

        }
    }

    public class LoadScreenComponent : MonoBehaviour
    {
        public static LoadScreenComponent Instance;
        private float target;
        public float FillSpeed = 1;
        public GameObject LoadScreenCanvas;
        public Image ProgressFill;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            if (CheckGood())
            {
                LoadScreen.SetLoaderCanvas(LoadScreenCanvas);
                LoadScreen.SetProgressBar(ProgressFill);
                LoadScreen.DisableLoadScreen();
            }
        }

        private bool CheckGood()
        {
            if (LoadScreenCanvas == null || ProgressFill == null)
            {
                Debug.LogWarning("Please make sure Load Screen canvas, and progress Fill are set in " + name);
                return false;
            }
            else return true;
        }

        public async void LoadScene(string sceneName)
        {
            DontDestroyOnLoad(LoadScreenCanvas);
            LoadScreen.ResetFill();
            target = 0;
            var scene = SceneManager.LoadSceneAsync(sceneName);
            scene.allowSceneActivation = false;
            LoadScreen.EnableLoadScreen();
            await Task.Delay(500);
                do
                {
                    target = scene.progress;
                } while (scene.progress < 0.9f);
            scene.allowSceneActivation = true;
            LoadScreen.DisableLoadScreen();
        }

        private void Update()
        {
            LoadScreen.UpdateFill(target, FillSpeed * Time.deltaTime);
        }
    }
}