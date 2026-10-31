using System;

namespace JetpackJoyride.Scripts.Common;

public sealed class InputKeyMap
{
    private static InputKeyMap instance = new InputKeyMap();
    public readonly String Jump = "Jump";

   public static InputKeyMap GetInstance => instance;
}
