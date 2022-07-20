using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private ShipController shipController;

    private void FixedUpdate()
    {
        slider.value = shipController.FuelPercentage;
    }
}
