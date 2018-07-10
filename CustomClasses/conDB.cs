using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace EmployeeM
{
    class conDB
    {
        String con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection conn;

        /*to close dataReader()*/
        public void closeConnection()
        {
            conn = new SqlConnection(con);
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        
        public int executeQry(String qry)
        {
            conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(qry,conn);
            int result = 0;
            try
            {
                conn.Open();
                try
                {
                    result = cmd.ExecuteNonQuery();
                    //MessageBox.Show("ssss");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            finally
            {
                conn.Close();
            }

            return result;
        }



        public SqlDataReader dataReader(String qry)
        {
            conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(qry,conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                try
                {
                    dr = cmd.ExecuteReader();
                    //MessageBox.Show("hariyoo");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return dr;
        }



        public object dataReaderScalar(String qry)
        {
            conn = new SqlConnection(con);
            object obj = null;
            SqlCommand cmd = new SqlCommand(qry,conn);

            try
            {
                conn.Open();
                try
                {
                    obj = cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }


            return obj;
        }

        

        public object getRowCount(String qry)
        {
            object obj = null;
            conn = new SqlConnection(con);
            SqlDataAdapter sdr = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            try
            {
                sdr.Fill(ds);
                obj = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            return obj;
        }



       
            public void AddParametersWithValues(String Query,params object [] SqlParameter)
            {
                conn = new SqlConnection("Data Source=DESKTOP-HOUSEMO;Initial Catalog=testITP1;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(Query,conn);
                
                
                cmd.Parameters.AddRange(SqlParameter);
            
            try
            {
                conn.Open();
                int rowsAffected = (int)cmd.ExecuteNonQuery();
                //MessageBox.Show("RowsAffected: {0} "+ rowsAffected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        

    }
}

