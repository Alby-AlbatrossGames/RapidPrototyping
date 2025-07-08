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

        private bool firstTimeDashBugFix = true;

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
        private int maxHoneyMoney = 10;
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
        }

        #endregion Start() and Update()

        #region UI
        [Header("UI")]
        public TMP_Text hpText;
        public TMP_Text mpText;
        public TMP_Text honeyText;
        #endregion UI

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
        private void Action2() => Debug.Log("[Action2]");
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
                Time.timeScale = 0;
                return;
            }
                
            int beeDMG = 20;
            StartCoroutine(FlashColour(Color.red));
            int curHP = hitPoints;
            hitPoints -= beeDMG;
            UpdateUI(hpText, curHP, hitPoints);

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
            if (firstTimeDashBugFix)
            { 
                firstTimeDashBugFix = false;
                yield break;
            }
            if (manaPoints <= 24)
                yield break;
            Color og = mat.material.color;

            int curMP = manaPoints;
            manaPoints -= 25;
            UpdateUI(mpText, curMP, manaPoints);

            transform.localScale = Vector3.one * 2 / 3;
            mat.material.color = Color.blueViolet;
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
            int curHoney = honeyMoney;
            honeyMoney += _num;
            UpdateUI(honeyText, curHoney, honeyMoney);
            manaPoints += 10;
            UpdateUI(mpText, manaPoints - 10, manaPoints);
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

