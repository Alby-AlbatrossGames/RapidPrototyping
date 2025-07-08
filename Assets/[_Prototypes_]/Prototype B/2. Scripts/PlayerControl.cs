using UnityEngine;
using _Universal.InputSystem;
using TMPro;
using System.Collections;
using DG.Tweening;
using ACX;

namespace Prototype2
{
    public class PlayerControl : GameBehaviour
    {
        [SerializeField] private float maxSpeed;
        public float dashTime = 0.7f;
        public float startupTime = 0.5f;

        int upgradeTier = 1;
        int upgradeLevel = 1;

        public int maxMult = 5;
        int minMult = 1;
        int curMult;
        Renderer mat;
        public GameObject gameOver;

        #region Variables

        [SerializeField] private bool impaired = false;

        public int hitPoints;
        public int manaPoints;
        public int honeyMoney;

        private int curHitPoints;
        private int curManaPoints;
        private int curHoneyMoney;

        private int maxHitPoints = 100;
        private int maxManaPoints = 100;
        private int maxHoneyMoney = 50;
        private float gameTime = 0;
        #endregion Variables

        #region Start() and Update()
        private void Start()
        {
            maxSpeed = 10;
            curMult = minMult;
            ResetHPMP();
            UpdateUI(hpText, 0, hitPoints, startupTime);
            UpdateUI(mpText, 0, manaPoints, startupTime);
            UpdateUI(honeyText, 999, 0, startupTime);

            mat = GetComponent<Renderer>();
            SetMaxValues();
            impaired = false;
        }

        private void Update() => gameTime = Time.time;

        private void SetMaxValues()
        {
            honeyMaxTxt.text = maxHoneyMoney.ToString();
            mpMaxTxt.text = maxManaPoints.ToString();
            hpMaxTxt.text = maxHitPoints.ToString();
        }

        #endregion Start() and Update()

        #region UI
        [Header("UI")]
        public TMP_Text hpText;
        public TMP_Text mpText;
        public TMP_Text honeyText;
        public TMP_Text honeyMaxTxt;
        public TMP_Text mpMaxTxt;
        public TMP_Text hpMaxTxt;

        public TMP_Text gameoverTimeTxt;
        public TMP_Text gameoverHoneyTxt;
        #endregion UI

        private int honeyCollected = 0;

        #region Movement
        private void MoveUp() => MovePlayer(0, maxSpeed);
        private void MoveDown() => MovePlayer(0, -maxSpeed);
        private void MoveLeft() => MovePlayer(-maxSpeed, 0);
        private void MoveRight() => MovePlayer(maxSpeed, 0);

        private void MovePlayer(float xdir = 0, float zdir = 0)
        {
            if (!impaired)
            {
                Vector3 direction = new Vector3(xdir, 0, zdir).normalized;
                transform.position += direction * maxSpeed * curMult * Time.deltaTime;
            }
        }

        #endregion Movement

        #region Actions
        private void Action1() => StartCoroutine(Dash());
        private void Action2() => UpgradePlayer();
        private void Action3() => Debug.Log("[Action3]");
        private void Action4() => Debug.Log("[Action4]");
        #endregion Actions

        #region Functions()

        public void UpdateUI(TMP_Text _txt, int _start, int _end, float _time = 0.4f) => TweenX.TweenNumbers(_txt, _start, _end, _time, DG.Tweening.Ease.InSine);

        public void TakeDamageFromBee(GameObject _null = null)
        {
            if (hitPoints <= 0)
            {
                GetComponent<Renderer>().enabled = false;
                gameOver.SetActive(true);
                impaired = true;

                gameoverHoneyTxt.text = honeyCollected.ToString() + "drops";
                gameoverTimeTxt.text = gameTime.ToString("F0") + "sec.";
                return;
            }
            StartCoroutine(FlashColour(Color.red));
            UpdateHealth(-20);

        }

        public void UpgradePlayer()
        {
            if (honeyMoney >= maxHoneyMoney)
            {
                UpdateHoney(-maxHoneyMoney);
                upgradeTier += 1;
                if (upgradeTier == 5)
                {
                    upgradeTier = 1;
                    upgradeLevel += 1;
                }

                int upgradeVal = 100 * (1 + (upgradeLevel / 100) * upgradeTier);
                UpgradeMaxHealth(upgradeVal);
            }
            
        }
        public IEnumerator FlashColour(Color _c, float _time = 0.2f)
        {
            Color og = mat.material.color;
            mat.material.color = _c;
            yield return new WaitForSeconds(_time/3);
            mat.material.color = og;
            yield return new WaitForSeconds(_time/3);
            mat.material.color = _c;
            yield return new WaitForSeconds(_time/3);
            mat.material.color = og;
        }
        void ResetHPMP()
        {
            hitPoints = maxHitPoints;
            manaPoints = maxManaPoints;
        }

        public IEnumerator Dash()
        {
            if (manaPoints <= 24)
                yield break;
            Color og = mat.material.color;

            UpdateMana(-25);

            transform.localScale = Vector3.one * 2 / 3;
            mat.material.color = Color.saddleBrown;
            curMult = maxMult;
            AC.ACLog("Speed: " + maxSpeed * curMult, this.name);
            yield return new WaitForSeconds(dashTime);
            curMult = minMult;
            AC.ACLog("Speed: " + maxSpeed * curMult, this.name);
            mat.material.color = og;
            transform.localScale = Vector3.one;
        }

        #endregion Functions()

        public void GainHoney(int _num)
        {
            UpdateHoney(10);
            UpdateMana(5);
        }

        /// <summary>
        /// Updates Health with an animation
        /// </summary>
        /// <param name="_val">amount of HP to add/remove</param>
        void UpdateHealth(int _val)
        {
            int curHP = hitPoints;
            hitPoints += _val;
            if (hitPoints < 0) hitPoints = 0;
            if (hitPoints > maxHitPoints) hitPoints = maxHitPoints;
            UpdateUI(hpText, curHP, hitPoints);
        }

        /// <summary>
        /// Updates Mana with an animation
        /// </summary>
        /// <param name="_val">amount of MANA to add/remove</param>
        void UpdateMana(int _val)
        {
            int curMANA = manaPoints;
            manaPoints += _val;
            if (manaPoints < 0) manaPoints = 0;
            if (manaPoints > maxManaPoints) manaPoints = maxManaPoints;
            UpdateUI(mpText, curMANA, manaPoints);
        }

        /// <summary>
        /// Updates Honey with an animation
        /// </summary>
        /// <param name="_val">amount of HONEY to add/remove</param>
        void UpdateHoney(int _val)
        {
            if (_val > 0) honeyCollected++;
            int curHONEY = honeyMoney;
            honeyMoney += _val;
            if (honeyMoney < 0) honeyMoney = 0;
            UpdateUI(honeyText, curHONEY, honeyMoney);
        }

        void UpgradeMaxHealth(int _val)
        {
            UpdateUI(hpMaxTxt, maxHitPoints, maxHitPoints + _val);
            maxHitPoints += _val;
        }

        #region EventListeners
        private void OnEnable()
        {
            InputEvents.OnInputUp += MoveUp;
            InputEvents.OnInputDown += MoveDown;
            InputEvents.OnInputLeft += MoveLeft;
            InputEvents.OnInputRight += MoveRight;

            InputEvents.OnInputAction1 += Action1;
            InputEvents.OnInputAction2 += Action2;
            InputEvents.OnInputAction3 += Action3;
            InputEvents.OnInputAction4 += Action4;

            GameEvents.OnBeeHitPlayer += TakeDamageFromBee;
        }
        private void OnDisable()
        {
            InputEvents.OnInputUp -= MoveUp;
            InputEvents.OnInputDown -= MoveDown;
            InputEvents.OnInputLeft -= MoveLeft;
            InputEvents.OnInputRight -= MoveRight;

            InputEvents.OnInputAction1 -= Action1;
            InputEvents.OnInputAction2 -= Action2;
            InputEvents.OnInputAction3 -= Action3;
            InputEvents.OnInputAction4 -= Action4;

            GameEvents.OnBeeHitPlayer -= TakeDamageFromBee;
        }
        #endregion EventListeners
    }
}

