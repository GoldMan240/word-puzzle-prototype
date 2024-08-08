using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.GameField
{
    public class Cluster : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private TextMeshProUGUI _lettersText;

        public string Letters => _lettersText.text;

        private const float RayDistance = 100f;
        private Vector3 _startLocalPosition;

        public void Setup(string letters)
        {
            _lettersText.text = letters;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startLocalPosition = transform.localPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Snap();
        }

        private void Snap()
        {
            if (!Camera.main) return;
            
            Ray ray = new(transform.position + Vector3.back, Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, RayDistance, LayerMask.GetMask("ClusterCell"));

            if (hit.collider && hit.collider.TryGetComponent(out ClusterCell clusterCell))
            {
                if (clusterCell.IsEmpty)
                {
                    transform.SetParent(clusterCell.transform);
                    transform.DOLocalMove(Vector3.zero, 0.25f);
                }
                else
                {
                    transform.DOLocalMove(_startLocalPosition, 0.25f);
                }
            }
            else
            {
                transform.DOLocalMove(_startLocalPosition, 0.25f);
            }
        }
    }
}