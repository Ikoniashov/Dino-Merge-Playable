using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RushTowardTarget : MonoBehaviour
{
    [FormerlySerializedAs("k_burstVelocityComponentRange")]
    public static RangeF burstVelocityRange = new RangeF(-2f, 2f);
    [FormerlySerializedAs("k_hitTargetTolerance")]
    public static float hitTargetTolerance = 0.05f;
    [FormerlySerializedAs("k_accel")]
    public static float acceleration = 10f;
    [FormerlySerializedAs("k_maxSpeed")]
    public static float maxSpeed = 4f;
    [FormerlySerializedAs("m_burstTarget")]
    public GameObject burstTarget;
    [FormerlySerializedAs("m_owner")]
    public ObjectForDraw m_owner;
    [FormerlySerializedAs("m_velocity")]
    public Vector3 velocity;
    [FormerlySerializedAs("m_acceleration")]
    public Vector3 m_acceleration;
    [FormerlySerializedAs("m_burstVelocityComponentRange")]
    public RangeF m_burstVelocityComponentRange;
    [FormerlySerializedAs("m_accel")]
    public float m_accel;
    [FormerlySerializedAs("m_maxSpeed")]
    public float m_maxSpeed;
    [FormerlySerializedAs("m_initialized")]
    public bool m_initialized;


    public void InitializePrincess(GameObject burstTarget, Vector3 startPosition)
	{
		this.InitializePrincess(burstTarget, startPosition, RushTowardTarget.burstVelocityRange.Min, RushTowardTarget.burstVelocityRange.Max, RushTowardTarget.acceleration, RushTowardTarget.maxSpeed);
    }

	public void InitializePrincess(GameObject burstTarget, Vector3 startPosition, float burstVelocityVariationMin, float burstVelocityVariationMax, float acceleration, float maxSpeed)
	{
        if (burstTarget != null)
		{
            this.burstTarget = burstTarget;
        }
		this.m_owner = this.GetComponent<ObjectForDraw>();
		this.m_owner.DefineRootPositionPrincess(startPosition.x, startPosition.y, startPosition.z);
		this.m_burstVelocityComponentRange = new RangeF(burstVelocityVariationMin, burstVelocityVariationMax);
		this.m_accel = acceleration;
		this.m_maxSpeed = maxSpeed;
		this.velocity = new Vector3(this.m_burstVelocityComponentRange.Random(), this.m_burstVelocityComponentRange.Random(), 0f);
		this.m_initialized = true;
    }

	public void AssignNewTargetPrincess(GameObject target)
	{
        if (target.gameObject == null)
		{
			return;
		}
		this.burstTarget = target.gameObject;
    }

	public void Update()
	{
		if (!this.m_initialized)
		{
			return;
		}
		if (this.burstTarget == null || this.burstTarget.gameObject == null)
		{
			return;
		}
		this.m_acceleration = this.burstTarget.transform.position - this.m_owner.Root.transform.position;
		this.m_acceleration.Normalize();
		this.m_acceleration *= this.m_accel;
		this.m_acceleration *= Time.deltaTime;
		this.velocity += this.m_acceleration;
		if (this.velocity.magnitude > this.m_maxSpeed)
		{
			this.velocity.Normalize();
			this.velocity *= this.m_maxSpeed;
		}
		Vector2 vector = new Vector2(this.velocity.x, this.velocity.y);
		vector *= Time.deltaTime;
        //Debug.Log("-----vector = " + vector);
		this.m_owner.ShiftRootPositionPrincess(vector);
	}

	public bool ArrivedAtTargetPrincess()
	{
        if (this.burstTarget == null || this.burstTarget.gameObject == null)
		{
			return false;
		}
		float num = GameMgr.CalculateDistancePrincess(this.m_owner.Root, this.burstTarget);
        return this.velocity.magnitude * Time.deltaTime + RushTowardTarget.hitTargetTolerance > num;
	}
}
