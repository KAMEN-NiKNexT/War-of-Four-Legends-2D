using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Kamen.UI;
using Kamen;
using WOFL.Control;
using Kamen.DataSave;
using Cysharp.Threading.Tasks;
using WOFL.Game;

namespace WOFL.UI
{
    public class UserProfilePopup : Popup
    {
        #region Variables

        [Header("User Datas Objects")]
        [SerializeField] private Image _userIcon;
        [SerializeField] private TextMeshProUGUI _userLevel;
        [SerializeField] private TextMeshProUGUI _userNameText;
        [SerializeField] private KamenButton _updateUserIcon;

        [Header("Addiotional Objects")]
        [SerializeField] private KamenButton _deleteAccountButton;
        [SerializeField] private MiniBattlePassView _miniBattlePassView;
        [SerializeField] private MiniDiamondPassView _miniDiamondPassView;

        #endregion

        #region Unity Methods

        private void OnDestroy()
        {
            DataSaveManager.Instance.MyData.OnIconNumberChanged -= UpdateUserIcon;
            _updateUserIcon.OnClick().RemoveListener(ShowUserIconsList);
            _deleteAccountButton.OnClick().RemoveListener(TryDeleteAccount);
        }

        #endregion

        #region Control Methods

        public async override void Initialize()
        {
            base.Initialize();

            await UniTask.WaitUntil(() => DataSaveManager.Instance.IsDataLoaded);
            await UniTask.WaitUntil(() => DataSaveManager.Instance.MyData.ChoosenFraction != Fraction.FractionName.None);

            UpdateUserIcon();
            _userNameText.text = DataSaveManager.Instance.MyData.Username;
            _userLevel.text = (DataSaveManager.Instance.MyData.GameLevel + 1).ToString();

            DataSaveManager.Instance.MyData.OnIconNumberChanged += UpdateUserIcon;

            _updateUserIcon.Initialize();
            _updateUserIcon.OnClick().AddListener(ShowUserIconsList);

            _deleteAccountButton.Initialize();
            _deleteAccountButton.OnClick().AddListener(TryDeleteAccount);
        }
        private void UpdateUserIcon()
        {
            _userIcon.sprite = FractionManager.Instance.CurrentFraction.PlayerProfileSettings.IconsList[DataSaveManager.Instance.MyData.IconNumber];
        }
        private void ShowUserIconsList()
        {
            PopupManager.Instance.Show("ChooseIconPopup");
        }
        private void TryDeleteAccount()
        {
            PopupManager.Instance.Show("ConfirmDeletaAccountPopup");
        }

        #endregion
    }
}

