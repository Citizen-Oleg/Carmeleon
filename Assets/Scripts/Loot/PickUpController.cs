using Interface;
using UnityEngine;

namespace Loot
{
    public class PickUpController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PickUpItem();
            }
        }

        private void PickUpItem()
        {
            var target = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHit = Physics2D.Raycast(target.origin, target.direction);

            if (raycastHit.collider == null) return;
            
            if (raycastHit.collider.TryGetComponent(out IDropItem dropItem))
            {
                dropItem.PickUp();
            }
        }
    }
}