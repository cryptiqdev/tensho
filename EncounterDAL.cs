using Sodium.Data;
using Sodium.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tensho.Data.DAL
{
	public class EncounterDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public EncounterDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Encounter table.
		/// </summary>
		public virtual void Insert(Encounter encounter)
		{
			ValidationUtility.ValidateArgument("encounter", encounter);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DeviceA", encounter.DeviceA),
				new SqlParameter("@DeviceB", encounter.DeviceB),
				new SqlParameter("@StartTime", encounter.StartTime),
				new SqlParameter("@DurationSeconds", encounter.DurationSeconds),
				new SqlParameter("@ClosestDistanceMeters", encounter.ClosestDistanceMeters),
				new SqlParameter("@AverageDistanceMeters", encounter.AverageDistanceMeters),
				new SqlParameter("@InternalComment", encounter.InternalComment),
				new SqlParameter("@CreatedBy", encounter.CreatedBy),
				new SqlParameter("@CreatedOn", encounter.CreatedOn),
				new SqlParameter("@AuditActionBy", encounter.AuditActionBy),
				new SqlParameter("@AuditActionOn", encounter.AuditActionOn)
			};

			encounter.ID = Convert.ToInt32(SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "EncounterInsert", parameters));
		}

		/// <summary>
		/// Updates a record in the Encounter table.
		/// </summary>
		public virtual void Update(Encounter encounter)
		{
			ValidationUtility.ValidateArgument("encounter", encounter);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", encounter.ID),
				new SqlParameter("@DeviceA", encounter.DeviceA),
				new SqlParameter("@DeviceB", encounter.DeviceB),
				new SqlParameter("@StartTime", encounter.StartTime),
				new SqlParameter("@DurationSeconds", encounter.DurationSeconds),
				new SqlParameter("@ClosestDistanceMeters", encounter.ClosestDistanceMeters),
				new SqlParameter("@AverageDistanceMeters", encounter.AverageDistanceMeters),
				new SqlParameter("@InternalComment", encounter.InternalComment),
				new SqlParameter("@CreatedBy", encounter.CreatedBy),
				new SqlParameter("@CreatedOn", encounter.CreatedOn),
				new SqlParameter("@AuditActionBy", encounter.AuditActionBy),
				new SqlParameter("@AuditActionOn", encounter.AuditActionOn)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EncounterUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Encounter table by its primary key.
		/// </summary>
		public virtual void Delete(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EncounterDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Encounter table.
		/// </summary>
		public virtual Encounter Select(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EncounterSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeEncounter(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Encounter table.
		/// </summary>
		public virtual List<Encounter> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EncounterSelectAll"))
			{
				List<Encounter> encounterList = new List<Encounter>();
				while (dataReader.Read())
				{
					Encounter encounter = MakeEncounter(dataReader);
					encounterList.Add(encounter);
				}
				dataReader.Close();

				return encounterList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Encounter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Encounter MakeEncounter(SqlDataReader dataReader)
		{
			Encounter encounter = new Encounter();
			encounter.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
			encounter.DeviceA = SqlClientUtility.GetString(dataReader, "DeviceA", String.Empty);
			encounter.DeviceB = SqlClientUtility.GetString(dataReader, "DeviceB", String.Empty);
			encounter.StartTime = SqlClientUtility.GetDateTime(dataReader, "StartTime", DateTime.Now);
			encounter.DurationSeconds = SqlClientUtility.GetInt32(dataReader, "DurationSeconds", 0);
			encounter.ClosestDistanceMeters = SqlClientUtility.GetDecimal(dataReader, "ClosestDistanceMeters", Decimal.Zero);
			encounter.AverageDistanceMeters = SqlClientUtility.GetDecimal(dataReader, "AverageDistanceMeters", Decimal.Zero);
			encounter.InternalComment = SqlClientUtility.GetString(dataReader, "InternalComment", String.Empty);
			encounter.CreatedBy = SqlClientUtility.GetString(dataReader, "CreatedBy", String.Empty);
			encounter.CreatedOn = SqlClientUtility.GetDateTime(dataReader, "CreatedOn", DateTime.Now);
			encounter.AuditActionBy = SqlClientUtility.GetString(dataReader, "AuditActionBy", String.Empty);
			encounter.AuditActionOn = SqlClientUtility.GetDateTime(dataReader, "AuditActionOn", DateTime.Now);

			return encounter;
		}

		#endregion
	}
}
