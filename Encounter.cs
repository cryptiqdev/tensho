using System;

namespace Tensho.Data
{
	[Serializable]
	public class Encounter
	{
		#region Fields

		private int iD;
		private string deviceA;
		private string deviceB;
		private DateTime startTime;
		private int durationSeconds;
		private decimal closestDistanceMeters;
		private decimal averageDistanceMeters;
		private string internalComment;
		private string createdBy;
		private DateTime createdOn;
		private string auditActionBy;
		private DateTime auditActionOn;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Encounter class.
		/// </summary>
		public Encounter()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Encounter class.
		/// </summary>
		public Encounter(string deviceA, string deviceB, DateTime startTime, int durationSeconds, decimal closestDistanceMeters, decimal averageDistanceMeters, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.deviceA = deviceA;
			this.deviceB = deviceB;
			this.startTime = startTime;
			this.durationSeconds = durationSeconds;
			this.closestDistanceMeters = closestDistanceMeters;
			this.averageDistanceMeters = averageDistanceMeters;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		/// <summary>
		/// Initializes a new instance of the Encounter class.
		/// </summary>
		public Encounter(int iD, string deviceA, string deviceB, DateTime startTime, int durationSeconds, decimal closestDistanceMeters, decimal averageDistanceMeters, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.iD = iD;
			this.deviceA = deviceA;
			this.deviceB = deviceB;
			this.startTime = startTime;
			this.durationSeconds = durationSeconds;
			this.closestDistanceMeters = closestDistanceMeters;
			this.averageDistanceMeters = averageDistanceMeters;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public virtual int ID
		{
			get { return iD; }
			set { iD = value; }
		}

		/// <summary>
		/// Gets or sets the DeviceA value.
		/// </summary>
		public virtual string DeviceA
		{
			get { return deviceA; }
			set { deviceA = value; }
		}

		/// <summary>
		/// Gets or sets the DeviceB value.
		/// </summary>
		public virtual string DeviceB
		{
			get { return deviceB; }
			set { deviceB = value; }
		}

		/// <summary>
		/// Gets or sets the StartTime value.
		/// </summary>
		public virtual DateTime StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}

		/// <summary>
		/// Gets or sets the DurationSeconds value.
		/// </summary>
		public virtual int DurationSeconds
		{
			get { return durationSeconds; }
			set { durationSeconds = value; }
		}

		/// <summary>
		/// Gets or sets the ClosestDistanceMeters value.
		/// </summary>
		public virtual decimal ClosestDistanceMeters
		{
			get { return closestDistanceMeters; }
			set { closestDistanceMeters = value; }
		}

		/// <summary>
		/// Gets or sets the AverageDistanceMeters value.
		/// </summary>
		public virtual decimal AverageDistanceMeters
		{
			get { return averageDistanceMeters; }
			set { averageDistanceMeters = value; }
		}

		/// <summary>
		/// Gets or sets the InternalComment value.
		/// </summary>
		public virtual string InternalComment
		{
			get { return internalComment; }
			set { internalComment = value; }
		}

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public virtual string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// Gets or sets the CreatedOn value.
		/// </summary>
		public virtual DateTime CreatedOn
		{
			get { return createdOn; }
			set { createdOn = value; }
		}

		/// <summary>
		/// Gets or sets the AuditActionBy value.
		/// </summary>
		public virtual string AuditActionBy
		{
			get { return auditActionBy; }
			set { auditActionBy = value; }
		}

		/// <summary>
		/// Gets or sets the AuditActionOn value.
		/// </summary>
		public virtual DateTime AuditActionOn
		{
			get { return auditActionOn; }
			set { auditActionOn = value; }
		}

		#endregion
	}
}
