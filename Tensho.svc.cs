using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Tensho.Data;
using Tensho.Data.DAL;
using Tensho.GatewayServiceReference;

namespace Tensho
{
    public class Tensho : ITensho
    {
        const string _connectionStringName = "HackathonConnectionString";

        public string Post(Encounter e)
        {
            try
            {
                //Thread myThread = new Thread(delegate ()
                //{
                    e.CreatedBy = string.Empty;
                    e.CreatedOn = System.DateTime.Now;
                    e.AuditActionBy = string.Empty;
                    e.AuditActionOn = System.DateTime.Now;

                    // This is wrong. A hack for the thon
                    // Write to blockchain
                    GatewayClient proxy = new GatewayClient();
                    e.InternalComment = proxy.Push(
                        "steash",
                        "steash",
                        JsonConvert.SerializeObject(e),
                        0); // 0 = No encryption

                    new EncounterDAL(_connectionStringName).Insert(e);
                //});
                //myThread.Start();
            }
            catch (Exception ex)
            {
                return ex.Message + ex.StackTrace;
            }

            return string.Empty;
        }

        public string Get(string device)
        {
            try
            {
                EncounterDAL encounterDAL = new EncounterDAL(_connectionStringName);

                string s = "This device owner met a person who has now been diagnosed with COVID-19.<br/>";

                List<Encounter> encounters = encounterDAL.SelectAll();
                encounters = encounters.Where(x => x.DeviceB == device).ToList();

                if (encounters.Count > 0)
                {
                    foreach (Encounter e in encounters)
                    {
                        s += "On " +
                            e.StartTime.ToShortDateString() +
                            "for " +
                            e.DurationSeconds +
                            " secondsat " +
                            e.AverageDistanceMeters.ToString("0.#") +
                            " meters average and " +
                            e.ClosestDistanceMeters.ToString("0.#") +
                            " meters closest. The blockchain key is " +
                            "<a href='http://blockchain.carbonfx.io/extract.aspx?guid=" + e.InternalComment + "'>" + e.InternalComment + "</a> or go to <a href='http://blockchain.carbonfx.io'>blockchain.carbonfx.io</a> and retreive a string using that key." + 
                            "<br/>";
                    }
                    //s += "This message is private by design. All you can ever know is time and distance.";
                }

                return s;
            }
            catch (Exception ex)
            {
                return ex.Message + ex.StackTrace;
            }
        }
    }
}
