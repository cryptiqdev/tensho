using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tensho.Data;
using Tensho.GatewayServiceReference;

namespace Tensho
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Met"] = false;

                ViewState["RegisterA"] = false;
                ViewState["RegisterB"] = false;

                ViewState["DiagnoseA"] = false;
                ViewState["DiagnoseB"] = false;

                ButtonDiagnoseA.Visible = false;
                ButtonDiagnoseB.Visible = false;

                ButtonMeet.Visible = false;

                LabelInstructions.Text = "This is the Tenshō simulator. Use these mobile phones to simulate proximity and diagnostic events." +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Start by registering both devices with the Tenshō service.";
            }
        }

        void DoState()
        {
            if ((bool)ViewState["RegisterA"])
            {
                ButtonRegisterA.Visible = false;
            }

            if ((bool)ViewState["RegisterB"])
            {
                ButtonRegisterB.Visible = false;
            }

            if ((bool)ViewState["RegisterA"] && (bool)ViewState["RegisterB"])
            {
                ButtonMeet.Visible = true;
                LabelInstructions.Text = "Now record meetings between the device owners, by pressing the Contact button. The simulator will assign a proximity and duration, and store the encounter on both devices.";
            }

            if ((bool)ViewState["Met"])
            {
                ButtonMeet.Text = "Meet Again";
                ButtonDiagnoseA.Visible = true;
                ButtonDiagnoseB.Visible = true;
                LabelInstructions.Text = "Congratulations. Your contacts have met. You can add more meetings, or diagnose one of the device owners with the COVID-19 disease.";
            }

            if ((bool)ViewState["DiagnoseA"] || (bool)ViewState["DiagnoseB"])
            {
                ButtonDiagnoseA.Visible = false;
                ButtonDiagnoseB.Visible = false;
                ButtonMeet.Visible = false;
                LabelInstructions.Text = "Now you've been through the Tenshō process. It couldn't be simpler.";
            }
        }

        protected void ButtonRegisterA_Click(object sender, EventArgs e)
        {
            ViewState["GuidA"] = Guid.NewGuid().ToString();
            ViewState["RegisterA"] = true;
            LabelGUIDA.Text = "This device's anonymous token is " + ViewState["GuidA"].ToString();
            DoState();
        }

        protected void ButtonRegisterB_Click(object sender, EventArgs e)
        {
            ViewState["GuidB"] = Guid.NewGuid().ToString();
            ViewState["RegisterB"] = true;
            LabelGUIDB.Text = "This device's anonymous token is " + ViewState["GuidB"].ToString();
            DoState();
        }

        protected void ButtonMeet_Click(object sender, EventArgs e)
        {
            try
            {
                Encounter encounter = new Encounter();

                encounter.DeviceA = ViewState["GuidA"].ToString();
                encounter.DeviceB = ViewState["GuidB"].ToString();
                encounter.StartTime = DateTime.Now;
                encounter.DurationSeconds = (new Random()).Next(30, 600);
                encounter.ClosestDistanceMeters = (new Random()).Next(1, 3);
                encounter.AverageDistanceMeters = encounter.ClosestDistanceMeters * (decimal)1.5;

                Tensho t = new Tensho();

                string message = t.Post(encounter);

                if (message.Length > 0)
                {
                    LabelInstructions.Text = message;
                }
                else
                {
                    encounter.DeviceA = ViewState["GuidB"].ToString();
                    encounter.DeviceB = ViewState["GuidA"].ToString();

                    t.Post(encounter);

                    if (message.Length > 0)
                    {
                        LabelInstructions.Text = message;
                    }
                }

                ViewState["Met"] = true;
                DoState();

            }
            catch(Exception ex)
            {
                LabelInstructions.Text = ex.Message;
            }
        }

        protected void ButtonDiagnoseA_Click(object sender, EventArgs e)
        {
            ViewState["DiagnoseA"] = true;
            LabelGUIDA.Text = "This device owner has been diagnosed with COVID-19. Their list of anonymous encounters has been posted to the blockchain, for exposed devices to collect and tell their owners.";
            LabelGUIDB.Text = GetEncounters(ViewState["GuidB"].ToString());
            DoState();
        }

        protected void ButtonDiagnoseB_Click(object sender, EventArgs e)
        {
            ViewState["DiagnoseB"] = true;
            LabelGUIDB.Text = "This device owner has been diagnosed with COVID-19. Their list of anonymous encounters has been posted to the blockchain, for exposed devices to collect and tell their owners.";
            LabelGUIDA.Text = GetEncounters(ViewState["GuidA"].ToString());
            DoState();
        }

        string GetEncounters(string guid)
        {
            Tensho t = new Tensho();
            string s = t.Get(guid);
            return s;
        }
    }
}