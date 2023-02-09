using UnityEngine;

public class PlayerInput : GameManager
{ 
    [SerializeField] private GameObject playerMovement;
    [SerializeField] private GameObject cartMovement;
    private IMovement iMovement;
    private float horizontalDirection;

    private void Awake()
    {
        iMovement = playerMovement.GetComponent<IMovement>();
        EventController.CartMoveEvent += CartMove;
        EventController.PlayerMoveEvent += PlayerMove;
    }

    private void Update()
    {
        if (!isPause && !isPlayerDeath && !isPlayerWon && !isCutScene)
        {
            horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
            if (Input.GetButtonDown(GlobalStringVars.JumpButton)) EventController.JumpButtonPressed();
            if (Input.GetButtonDown(GlobalStringVars.Fire1)) EventController.Fire1ButtonPressed();
            if (Input.GetButtonDown(GlobalStringVars.Fire2)) EventController.Fire2ButtonPressed();
            if (Input.GetButtonDown(GlobalStringVars.UseButton)) EventController.UseButtonPressed();
        }
        else horizontalDirection = 0;

        if (Input.GetButtonDown(GlobalStringVars.MenuButton)) EventController.MenuButtonPressed();
    }

    private void FixedUpdate()
    {
        if (!isPause && !isPlayerDeath && !isPlayerWon && !isCutScene)
        {
            iMovement.Move(horizontalDirection);
            EventController.JumpButtonPressedEvent += iMovement.Jump;
            iMovement.Animations();
        }
    }

    private void CartMove()
    {
        iMovement = cartMovement.GetComponent<IMovement>();
    }

    private void PlayerMove()
    {
        iMovement = playerMovement.GetComponent<IMovement>();
    }
}
