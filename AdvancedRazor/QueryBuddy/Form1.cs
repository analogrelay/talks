using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using WebMatrix.Data;

namespace QueryBuddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            IEnumerable<dynamic> rows = null;
            
            // Connect to the database
            using (SqlConnection cnn = new SqlConnection(@"Data Source=KANG\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                cnn.Open();
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    // Send our query and get the data back
                    cmd.CommandText = queryTextBox.Text;

                    // Convert it to a list of dynamic objects
                    rows = cmd.ExecuteReader().ToDynamicList();

                    // Run the template over the data
                    var config = new TemplateServiceConfiguration()
                    {
                        BaseTemplateType = typeof(ReportTemplate)
                    };
                    Razor.SetTemplateService(new TemplateService(config));
                    var render = Razor.Parse(templateTextBox.Text, rows);

                    // Stuff the content in the web browser control
                    previewBrowser.DocumentText = render;
                    button1.Enabled = true;
                }
            }
        }
    }
}
