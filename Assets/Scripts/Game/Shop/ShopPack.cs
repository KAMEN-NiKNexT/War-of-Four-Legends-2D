using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WOFL.UI
{
    public class ShopPack : MonoBehaviour
    {
        #region Variables

        [Header("Obejcts")]
        [SerializeField] private ProductPackBar _productPackBar;
        [SerializeField] private GameObject _productsHolder;

        [Header("Variables")]
        private List<ProductPanel> _productsPanel = new List<ProductPanel>();

        #endregion

        #region Properties

        public GameObject ProductsHolder { get => _productsHolder; }

        #endregion

        #region Control Methods

        public void Initialize(string name, List<ProductPanel> productPanel)
        {
            _productPackBar.Initialize(name);
            _productsPanel = productPanel;
        }

        #endregion
    }
}