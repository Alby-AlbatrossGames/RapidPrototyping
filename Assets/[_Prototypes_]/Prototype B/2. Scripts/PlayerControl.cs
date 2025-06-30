using UnityEngine;

public class PlayerControl : GameBehaviour
{
    [SerializeField] private float maxSpeed;

    private void Start()
    {
        maxSpeed = 10;
    }

    #region Movement
    private void MoveUp() => MovePlayer(0, maxSpeed);
    private void MoveDown() => MovePlayer(0, -maxSpeed);
    private void MoveLeft() => MovePlayer(-maxSpeed, 0);
    private void MoveRight() => MovePlayer(maxSpeed, 0);
    #endregion Movement

    #region Actions
    private void Action1() => Debug.Log("[Action1]");
    private void Action2() => Debug.Log("[Action2]");
    private void Action3() => Debug.Log("[Action3]");
    private void Action4() => Debug.Log("[Action4]");
    #endregion Actions

    #region Functions()

    private void MovePlayer(float xdir = 0, float zdir = 0)
    {
        Vector3 direction = new Vector3(xdir, 0, zdir).normalized;
        transform.position += direction * maxSpeed * Time.deltaTime;
    }

    #endregion Functions()

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
    }
    #endregion EventListeners
}
