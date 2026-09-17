public static class PlayableCta
{
    private static bool s_started;
    private static bool s_ended;

    public static void GameStarted()
    {
        if (s_started)
            return;

        s_started = true;
        Luna.Unity.LifeCycle.GameStarted();
    }

    public static void GameEnded()
    {
        if (s_ended)
            return;

        s_ended = true;
        Luna.Unity.LifeCycle.GameEnded();
    }

    public static void OpenStore()
    {
        Luna.Unity.Playable.InstallFullGame();
    }

    public static void FinishAndOpenStore()
    {
        GameEnded();
        OpenStore();
    }
}
