using UnityEngine;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;
public class PlanesManager : MonoBehaviour
{
    private MLPlanesBehavior _planesBehavior;

    public MLPlanes.Plane Floor { get; private set; }
    public Vector3 RoomCentre { get; private set; }

    public MLPlanes.Plane MainWall { get; private set; }
    public Vector3 WallCentre { get; private set; }

    private MLPlanesBehavior.SemanticFlags _findingPlaneType;
    private void Awake()
    {
        RoomCentre = Vector3.zero;
        WallCentre = Vector3.zero;
        TryGetComponent<MLPlanesBehavior>(out _planesBehavior);
        _planesBehavior.OnQueryPlanesResult += OnQueriedPlanes;
        ActivateFindingFloor();
        Invoke(nameof(ActivateFindingWalls), 2f);
    }
    private void ActivateFindingFloor()
    {
        _findingPlaneType = MLPlanesBehavior.SemanticFlags.Floor;
        _planesBehavior.semanticFlags = MLPlanesBehavior.SemanticFlags.Floor;
        _planesBehavior.orientationFlags = MLPlanesBehavior.OrientationFlags.Horizontal;
    }
    private void ActivateFindingWalls()
    {
        _findingPlaneType = MLPlanesBehavior.SemanticFlags.Wall;
        _planesBehavior.semanticFlags = MLPlanesBehavior.SemanticFlags.Wall;
        _planesBehavior.orientationFlags = MLPlanesBehavior.OrientationFlags.Vertical;
    }
    private void OnQueriedPlanes(MLPlanes.Plane[] planes, MLPlanes.Boundaries[] boundaries)
    {
        switch (_findingPlaneType)
        {
            case MLPlanesBehavior.SemanticFlags.Ceiling:
                break;

            case MLPlanesBehavior.SemanticFlags.Floor:
                FindFloor(planes);
                break;

            case MLPlanesBehavior.SemanticFlags.Wall:
                FindMainWall(planes);
                break;

            default:
                break;
        }
    }
    private float PlaneArea(MLPlanes.Plane plane)
    {
        return plane.Height * plane.Width;
    }
    private void FindFloor(MLPlanes.Plane[] planes)
    {
        Floor = planes[0];
        foreach (MLPlanes.Plane plane in planes)
        {
            if (PlaneArea(plane) > PlaneArea(Floor))
            {;
                Floor = plane;
            }
            RoomCentre = Floor.Center;
        }
    }
    private void FindMainWall(MLPlanes.Plane[] planes)
    {
        MainWall = planes[0];
        foreach (MLPlanes.Plane plane in planes)
        {
            if (PlaneArea(plane) > PlaneArea(MainWall))
            {
                MainWall = plane;

            }
            WallCentre = MainWall.Center;
        }
    }
}
