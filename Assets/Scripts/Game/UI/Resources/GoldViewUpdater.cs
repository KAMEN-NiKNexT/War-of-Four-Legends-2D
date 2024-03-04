using Kamen.DataSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WOFL.Control;

namespace WOFL.UI
{
    public class GoldViewUpdater : CurrencyViewUpdaterBase
    {
        #region Control Methods

        protected override void Initialize()
        {
            base.Initialize();
            DataSaveManager.Instance.MyData.OnGoldAmountChanged += UpdateText;
            UpdateText();
        }

        protected override void Unsubscribe()
        {
            DataSaveManager.Instance.MyData.OnGoldAmountChanged -= UpdateText;
        }

        protected override void UpdateText() => _viewText.text = BigNumberViewConverter.Instance.Convert(DataSaveManager.Instance.MyData.Gold);

        #endregion
    }
}