using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private ISceneLoadMediator _sceneLoadMediator;
    private Wallet _wallet;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoadMediator, Wallet wallet)
    {
        _sceneLoadMediator = sceneLoadMediator;
        _wallet = wallet;
    }

    private void OnEnable()
        => _mainMenuButton.onClick.AddListener(OnMainMenuClick);

    private void OnDisable()
        => _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);

    private void OnMainMenuClick() => _sceneLoadMediator.GoToMainMenu();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            if (_wallet.IsEnough(10))
                _wallet.Spend(10);

        if(Input.GetKeyUp(KeyCode.F))
            _wallet.AddCoins(10);
    }
}
