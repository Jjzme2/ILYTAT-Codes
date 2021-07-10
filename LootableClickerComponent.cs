using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Clicker {

    [RequireComponent(typeof(LootableSelector))]
    public class LootableClickerComponent : MonoBehaviour
    {
        public CO_LootableClicker GetSelected { get; private set; }
        public SliderController GetEnemyHealthController;
        public SliderController GetTimerController;
        public float SpawnRate = 1.33f;
        private SpriteRenderer rend => GetComponentInChildren<SpriteRenderer>();
        public TMProUGUIHandler GetTMProHandler;
        public Animator GetAnim => GetComponentInChildren<Animator>();
        private LootableSelector sel => GetComponent<LootableSelector>();
        public TMProUGUIHandler VictoryText;


        private void OnEnable()
        {
            Spawn();
        }

        private void CheckFade(float desiredFade = 1)
        {
            if (rend.color.a != desiredFade)
            {
                Color c = rend.color;
                rend.color = new Color(c.r, c.g, c.b, desiredFade);
            }
        }

        private void Spawn()
        {
            VictoryText.gameObject.SetActive(false);
            CheckFade();
            GetSelected = sel.GetRandomSelection;
            
            if (GetTMProHandler == null)
            {
                GetSelected.Spawn(rend);
                rend.enabled = true;
            }
            else
            {
                GetSelected.Spawn(rend, GetTMProHandler);
                rend.enabled = true;
                GetTMProHandler.enabled = true;
            }
            GetAnim.enabled = true;
            GetTMProHandler.UpdateText(GetSelected.ClickerName);
            GetTMProHandler.gameObject.SetActive(true);
            GetEnemyHealthController.referencedData = GetSelected.GetHealthSliderData;
            GetTimerController.referencedData = GetSelected.GetTimerData;
            GetEnemyHealthController.gameObject.SetActive(true);
            GetTimerController.gameObject.SetActive(true);
            BeginTimer();
        }

        private void BeginTimer()
        {
            InvokeRepeating("ReduceTimer", 0, .1f);
        }

        private void ReduceTimer()
        {
            GetTimerController.referencedData.Reduce(.1f);
        }

        private void Death()
        {
            Debug.Log("Dead.");
            GetAnim.enabled = false;
            rend.enabled = false;
            if(GetTMProHandler != null)
            {
                GetTMProHandler.enabled = false;
            }
            GetTMProHandler.gameObject.SetActive(false);
            GetTMProHandler.UpdateText("");
            GetEnemyHealthController.gameObject.SetActive(false);
            GetTimerController.gameObject.SetActive(false);
            GetEnemyHealthController.referencedData = null;
            VictoryText.gameObject.SetActive(true);
            VictoryText.UpdateText("Exp Gain: " + GetSelected.cLoot.GetExpGain + "\n" + "Money Gain: " + GetSelected.cLoot.GetMoneyGain);
            Invoke("Spawn", SpawnRate);
        }

        public void OnClick(float damageAmount)
        {
            if (GetEnemyHealthController.referencedData == null)
            {
                Debug.Log("Click attempted, but no data to recieve.");
                return;
            }
            else
            {
                GetAnim.SetTrigger("Hurt");
                GetEnemyHealthController.referencedData.ChangeValue(-damageAmount);
                if (GetEnemyHealthController.GetCur <= 0)
                {
                    Death();
                }
            }
        }
    }   
}