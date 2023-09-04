using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _loader;

    public SceneLoader(ZenjectSceneLoaderWrapper loader) => _loader = loader;

    public void Load(LevelLoadingData levelLoadingData)
    {
        _loader.Load(container =>
        {
            container.BindInstance(levelLoadingData).WhenInjectedInto<GameplaySceneInstaller>();
        }, (int)SceneID.GameplayLevel);
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayLevel)
            throw new ArgumentException($"{SceneID.GameplayLevel} cannot be started withoout configuration");

        _loader.Load(null, (int)sceneID);
    }
}
