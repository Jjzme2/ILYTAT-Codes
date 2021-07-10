using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ILYTATTools.Patterns;
using System;

namespace ILYTATTools.Clicker
{
    [System.Serializable]
    public class PlayerData
    {
        private int maxHealth = 100;
        private SliderData playerData => SliderData.CreateNewSliderData(maxHealth);
        public float GetCurHealth => playerData.GetCur;
        public int GetAttack { get; private set; }


        public static PlayerData CreateNew(int maxHealth, int attack = 1)
        {
            PlayerData d = new PlayerData();

            d.maxHealth = maxHealth;
            d.GetAttack = attack;
            return d;
        }

        public void IncreaseAttack(int additiveAmount)
        {
            GetAttack += additiveAmount;
        }

        public void IncreaseMaxHealth(int additiveAmount, bool fill) 
        {
            maxHealth += additiveAmount;
            playerData.SetMax(maxHealth);

            if (fill)
            {
                FillHealth();
            }
        }

        public void FillHealth()
        {
            playerData.SetValue(maxHealth);
        }

        public void SaveData()
        {

        }
    }


    public class ClickerPlayer : MonoBehaviour
    {
        public GameObject ClickerObject;
        private PlayerControls myControls;
        private PlayerData data = null;
        private LootableClickerComponent clicker => ClickerObject.GetComponent<LootableClickerComponent>();
        private int startingHealth = 100;

        public PlayerData GetPlayerData
        {
            get
            {
                if(data == null)
                {
                    data = PlayerData.CreateNew(startingHealth);
                }
                return data;
            }
        } 

        private void Awake()
        {
            myControls = new PlayerControls();
        }

        private void OnEnable()
        {
            data = GetPlayerData;
            myControls.Enable();
        }

        private void OnDisable()
        {
            myControls.Disable();
        }

        private void Update()
        {
            if (myControls.PlayerMap.Tap.triggered)
            {
                PlayerClicked();
            }
        }
        private void PlayerClicked()
        {
            clicker.OnClick(data.GetAttack);
        }
    }
}
