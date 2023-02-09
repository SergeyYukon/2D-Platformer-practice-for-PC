using System;

public class EventController
{
    public static Action MenuButtonPressedEvent;
    public static Action UseButtonPressedEvent;
    public static Action Fire1ButtonPressedEvent;
    public static Action Fire2ButtonPressedEvent;
    public static Action JumpButtonPressedEvent;
    public static Action<float>PlayerDeathEvent;
    public static Action EnemyDeathEvent;
    public static Action LeftDirectionEvent;
    public static Action RightDirectionEvent;
    public static Action CartMoveEvent;
    public static Action PlayerMoveEvent;
    public static Action GetChestEvent;
    public static Action CutSceneEvent;

    public static void ResetEvents()
    {
        MenuButtonPressedEvent = null;
        UseButtonPressedEvent = null;
        Fire1ButtonPressedEvent = null;
        Fire2ButtonPressedEvent = null;
        JumpButtonPressedEvent = null;
        PlayerDeathEvent = null;
        EnemyDeathEvent = null;
        LeftDirectionEvent = null;
        RightDirectionEvent = null;
        CartMoveEvent = null;
        PlayerMoveEvent = null;
        GetChestEvent = null;
        CutSceneEvent = null;
    }

    public static void MenuButtonPressed() => MenuButtonPressedEvent?.Invoke();

    public static void UseButtonPressed() => UseButtonPressedEvent?.Invoke();

    public static void Fire1ButtonPressed() => Fire1ButtonPressedEvent?.Invoke();

    public static void Fire2ButtonPressed() => Fire2ButtonPressedEvent?.Invoke();

    public static void JumpButtonPressed() => JumpButtonPressedEvent?.Invoke();

    public static void PlayerDeath(float lateDeathTime) => PlayerDeathEvent?.Invoke(lateDeathTime);

    public static void EnemyDeath() => EnemyDeathEvent?.Invoke();

    public static void LeftDirection() => LeftDirectionEvent?.Invoke();

    public static void RightDirection() => RightDirectionEvent?.Invoke();

    public static void CartMove() => CartMoveEvent?.Invoke();

    public static void PlayerMove() => PlayerMoveEvent?.Invoke();

    public static void GetChest() => GetChestEvent?.Invoke();

    public static void CutScene() => CutSceneEvent?.Invoke(); 
}
