        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable tblcsv = new DataTable();
            tblcsv.Columns.Add("Process");
            tblcsv.Columns.Add("Total Asset");
            tblcsv.Columns.Add("WFH assets");
            tblcsv.Columns.Add("CSA System");
            tblcsv.Columns.Add("Support System");
            tblcsv.Columns.Add("Order Value");
            tblcsv.Columns.Add("WFO");
            tblcsv.Columns.Add("5 % Increase");
            tblcsv.Columns.Add("Faulty System");
            tblcsv.Columns.Add("Total");
            tblcsv.Columns.Add("Require Count");
            tblcsv.Columns.Add("IT Remarks");
            string CSVFilePath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (FileUpload1.PostedFile.FileName != "")
            {
                FileUpload1.SaveAs(CSVFilePath);
                string ReadCSV = File.ReadAllText(CSVFilePath);
                foreach (string csvRow in ReadCSV.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                            count++;
                            
                        }
                    }
                }
                tblcsv.Rows.Remove(tblcsv.Rows[0]);  
                InsertCSVRecords(tblcsv);
            }
            else
            {
                Response.Write("<script>alert('Please Select File To Import.')</script>");
            }
        }
        private void InsertCSVRecords(DataTable csvdt)
        {
            string STRCON = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(STRCON);
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "[ITDB].[dbo].[ASTTRCKRTBLL]";
            objbulk.ColumnMappings.Add("Process", "dropPrnm");
            objbulk.ColumnMappings.Add("Total Asset", "textTAssets");
            objbulk.ColumnMappings.Add("WFH assets", "textwfhAssets");
            objbulk.ColumnMappings.Add("CSA System", "textsystm");
            objbulk.ColumnMappings.Add("Support System", "textSSytm");
            objbulk.ColumnMappings.Add("Order Value", "textOval");
            objbulk.ColumnMappings.Add("WFO", "textWFo");
            objbulk.ColumnMappings.Add("5 % Increase", "textincrs");
            objbulk.ColumnMappings.Add("Faulty System", "textFsystm");
            objbulk.ColumnMappings.Add("Total", "textTotl");
            objbulk.ColumnMappings.Add("Require Count", "textRcnt");
            objbulk.ColumnMappings.Add("IT Remarks", "textItrmrks");
            con.Open();
            objbulk.WriteToServer(csvdt);
            con.Close();
        }
