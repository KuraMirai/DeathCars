using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class BaseAnimationComponent : MonoBehaviour
{
    [SerializeField] private Transform menuContainer;
    [SerializeField] private Transform fromPosition;
    [SerializeField] private Transform toPosition;
    [SerializeField] private float openTime;
    [SerializeField] private float closeTime;

    private void Awake()
    {
        menuContainer.position = fromPosition.position;
    }

    public async Task PlayOpen()
    {
        await menuContainer.DOMove(toPosition.position, openTime).AsyncWaitForCompletion();
    }

    public void PlayClose()
    {
        menuContainer.DOMove(fromPosition.position, closeTime);
    }
}