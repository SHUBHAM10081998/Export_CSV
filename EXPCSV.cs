        protected void CSV(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [ITDB].[dbo].[ASTTRCKRTBLL]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            string csv = string.Empty;
                            string cs = "";
                            foreach (DataColumn column in dt.Columns)
                            {
                                
                                csv += column.ColumnName + ',';
                                string id = "id,dropPrnm,textTAssets,textwfhAssets,textsystm,textSSytm,textOval,textWFo,textincrs,textFsystm,textTotl,textRcnt,textItrmrks";
                                string SrNo = "SrNo,Process,Total Asset,WFH assets,CSA System,Support System,Order Value,WFO,5 % Increase,Faulty System,Total,Require Count,IT Remarks";

                                cs = csv.Replace(id, SrNo);
                            }
                            cs += "\r\n";
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    cs += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                                }
                                cs += "\r\n";
                            }
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=Export.csv");
                            Response.Charset = "";
                            Response.ContentType = "application/text";
                            Response.Output.Write(cs);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }
